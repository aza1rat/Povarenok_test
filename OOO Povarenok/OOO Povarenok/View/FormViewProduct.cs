using OOO_Povarenok.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OOO_Povarenok
{

    public partial class FormViewProduct : Form
    {
        private List<string[]> categories;
        private List<string[]> manufactories;
        private List<string[]> products;
        private int productsCount;
        private String maxItemsOnPage;
        private int selectedPage = 1;
        private int selectedRow = -1;
        
        public FormViewProduct()
        {
            InitializeComponent();
            Helper.CurrentOrder.Clear();
            OrderProduct.orderId = -1;
        }

        private void FormViewProduct_Load(object sender, EventArgs e)
        {
            if (Helper.User == null)
                LabelUser.Text = "";
            else
                LabelUser.Text = Helper.User.userSurname + "\n" + Helper.User.userName + "\n" + Helper.User.userPatronymic;
            selectedRow = -1;
            if (Helper.User is null || Helper.User.userRole != User.UserRole.Администратор)
            {
                ButtonAddProduct.Enabled = false;
                ButtonAddProduct.Visible = false;
                
            }
            if (Helper.CurrentOrder.Count == 0)
            {
                ButtonOrder.Enabled = false;
                ButtonOrder.Visible = false;
            }

            if (Helper.User != null && Helper.User.userRole != User.UserRole.Администратор)
                DGVProducts.ContextMenuStrip = ContextMenuProduct;
            else
                DGVProducts.ContextMenuStrip = null;

            TableLayPanVProdUp.BackColor = Color.FromArgb(255, 204, 153);
            TableLayPanVProdDown.BackColor = Color.FromArgb(255, 204, 153);
            string[] counts = SQLHelper.GetOneRow("Count([ProductArticleNumber])", "[Product]");
            productsCount = Convert.ToInt32(counts[0]);
            CBCategory.Items.Clear();
            CBCategory.Items.Add("Все категории");
            categories = SQLHelper.GetRows("*", "[Category]","");
            manufactories = SQLHelper.GetRows("*", "[Manufacturer]","");
            products = SQLHelper.GetRows("*", "[Product]", "");
            
            foreach (string[] category in categories)
            {
                CBCategory.Items.Add(category[1]);
            }
            CBItemsOnPage.SelectedIndex = 0;
            CBCategory.SelectedIndex = 0;
            CBCost.SelectedIndex = 0;
            CBDiscount.SelectedIndex = 0;
            selectedPage = 1;
            UpdateDataFromDB();
            
        }

        private void UpdateGrid()
        {
            int viewProductsCount = 0;
            DGVProducts.Rows.Clear();
            foreach (string[] product in products)
            {
                if (maxItemsOnPage != "Все" && viewProductsCount >= int.Parse(maxItemsOnPage))
                    break;
                if (IsHaveLetter(product[1], TextBoxSearch.Text) == false)
                {
                    continue;
                }
                int id = DGVProducts.Rows.Add();
                DGVProducts.Rows[id].Height = 120;
                string text = "";
                if (product[5] != null)
                {
                    MemoryStream ms = SQLHelper.GetImageProduct(product[0]);
                    try
                    {
                        Bitmap bitmap = (Bitmap)Image.FromStream(ms);
                        DGVProducts.Rows[id].Cells[0].Value = bitmap;
                    }
                    catch
                    {
                        Bitmap bitmap = (Bitmap)Resources.image;
                        DGVProducts.Rows[id].Cells[0].Value = bitmap;
                    }

                }
                DGVProducts.Rows[id].Cells[0].Tag = product[0];
                double cost = Convert.ToDouble(product[8]);
                double discount = Convert.ToDouble(product[9]);
                cost = cost - (cost / 100 * discount);
                text = "Наименование: " + product[1] + Environment.NewLine;
                text += "Описание: " + product[3] + Environment.NewLine;
                text += "Производитель: " + GetInfo(manufactories, product[6]) + Environment.NewLine;
                text += "Цена: " + product[8] + Environment.NewLine;
                if (product[9] != "0")
                {
                    text += "Скидка: " + product[10] + "%" + Environment.NewLine;
                    text += "Со скидкой: " + cost + Environment.NewLine;
                    if (double.Parse(product[10]) > 15)
                        DGVProducts.Rows[id].DefaultCellStyle.BackColor = Color.FromArgb(204, 102, 0);
                }
                DGVProducts.Rows[id].Cells[1].Value = text;
                viewProductsCount++;
            }
            if (DGVProducts.Rows.Count == 0 && selectedPage > 1)
            {
                selectedPage -=1;
                UpdateDataFromDB();

            }
            LabelValuePage.Text = selectedPage.ToString();
            LabelCountShow.Text = $"Показано {DGVProducts.Rows.Count} из {productsCount}";
        }

        private Boolean IsHaveLetter(String str, String letters)
        {
            if (letters == null || letters == "")
                return true;
            return str.Contains(letters);
        }

        private String GetInfo(List<string[]> list, string id)
        {
            foreach (string[] infos in list)
            {
                if (infos[0] == id)
                    return infos[1];
            }
            return null;
        }

        private String GetID(List<string[]> list, string value)
        {
            foreach (string[] infos in list)
            {
                if (infos[1] == value)
                    return infos[0];
            }
            return null;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButViewProdutBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBDiscount_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedPage = 1;    
            UpdateDataFromDB();

        }

        private void UpdateDataFromDB()
        {
            if (CBCategory.SelectedItem == null || CBCost.SelectedItem == null || CBDiscount.SelectedItem == null || CBItemsOnPage.SelectedItem == null)
                return;
            string parameters = "WHERE ";
            if (CBCategory.SelectedItem.ToString() != "Все категории")
                parameters += "[ProductCategory] = " + GetID(categories, CBCategory.SelectedItem.ToString()) + " AND ";
            switch (CBDiscount.SelectedItem.ToString())
            {
                case "0-9.99%": parameters += "[ProductMaxDiscount] > 0 AND [ProductMaxDiscount] <= 9.99"; break;
                case "10-14.99%": parameters += "[ProductMaxDiscount] >= 10 AND [ProductMaxDiscount] <= 14.99"; break;
                case "> 15%": parameters += "[ProductMaxDiscount] >= 15"; break;
                default:
                    if (CBCategory.SelectedItem.ToString() != "Все категории")
                        parameters = parameters.Substring(0, parameters.Length - 4);
                    break;
            }
            if (CBCategory.SelectedItem.ToString() == "Все категории" && CBDiscount.SelectedItem.ToString() == "Все диапазоны")
                parameters = "";
            if (CBCost.SelectedItem.ToString() == "По возрастанию")
                parameters += "ORDER BY [ProductCost] ASC";
            if (CBCost.SelectedItem.ToString() == "По убыванию")
                parameters += "ORDER BY [ProductCost] DESC";

            maxItemsOnPage = CBItemsOnPage.SelectedItem.ToString();
            if (maxItemsOnPage != null && maxItemsOnPage != "Все")
            {
                int itempsPage = int.Parse(maxItemsOnPage);
                int offset = (selectedPage - 1) * itempsPage;
                parameters += " OFFSET " + offset + " ROWS";
            }

            products = SQLHelper.GetRows("*", "[Product]", parameters);
            
            UpdateGrid();

        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            selectedPage = 1;
            UpdateGrid();
        }

        private void ButFirstPage_Click(object sender, EventArgs e)
        {
            selectedPage = 1;
            UpdateDataFromDB();
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (maxItemsOnPage == "Все")
                return;
            if (selectedPage == 1)
                return;
            selectedPage -= 1;
            UpdateDataFromDB();
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (maxItemsOnPage == "Все")
                return;
            int pages = 0;
            int ost = productsCount % int.Parse(maxItemsOnPage);
            if (ost != 0)
                pages++;
            pages += productsCount / int.Parse(maxItemsOnPage);
            if (selectedPage >= pages)
                return;
            selectedPage++;
            UpdateDataFromDB();
        }

        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            if (maxItemsOnPage == "Все")
                return;
            int pages = 0;
            int ost = productsCount % int.Parse(maxItemsOnPage);
            if (ost != 0)
                pages++;
            pages += productsCount / int.Parse(maxItemsOnPage);
            selectedPage = pages;
            UpdateDataFromDB();
        }

        private void DGVProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (Helper.User is null || Helper.User.userRole != User.UserRole.Администратор)
                return;
            FormChangeProduct changeProduct = new FormChangeProduct(DGVProducts.Rows[e.RowIndex].Cells[0].Tag.ToString(), Helper.User);
            this.Hide();
            changeProduct.ShowDialog();
            this.Show();
            FormViewProduct_Load(null, null);
        }



        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            FormChangeProduct changeProduct = new FormChangeProduct();
            this.Hide();
            changeProduct.ShowDialog();
            this.Show();
            FormViewProduct_Load(null, null);
        }

        private void AddProductStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedRow < 0)
                return;
            string article = DGVProducts.Rows[selectedRow].Cells[0].Tag.ToString();
            bool isNewArticle = true;
            for (int i = 0; i< Helper.CurrentOrder.Count; i++)
            {
                if (Helper.CurrentOrder[i].articleProduct == article)
                {
                    Helper.CurrentOrder[i].count++;
                    isNewArticle = false;
                }
            }
            if (isNewArticle)
            {
                Helper.CurrentOrder.Add(new OrderProduct { articleProduct = article, count = 1 });
            }
            ButtonOrder.Visible = true;
            ButtonOrder.Enabled = true;


        }

        private void DGVProducts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Helper.User is null || Helper.User.userRole == User.UserRole.Администратор)
                {
                    selectedRow = -1;
                    return;
                }
                selectedRow = DGVProducts.HitTest(e.X, e.Y).RowIndex;
            }
        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            FormOrder formOrder = new FormOrder();
            formOrder.ShowDialog();
            FormViewProduct_Load(null, null);
        }
    }
}
