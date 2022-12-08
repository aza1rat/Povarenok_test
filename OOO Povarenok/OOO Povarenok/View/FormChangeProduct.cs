using OOO_Povarenok.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOO_Povarenok
{
    public partial class FormChangeProduct : Form
    {
        string[] product;
        public FormChangeProduct()
        {
            InitializeComponent();
            DisplaySources();
            PictureBoxProduct.Image = Resources.image;

        }

        public FormChangeProduct(string article, User user)
        {
           
            InitializeComponent();
            LabelOrdersUser.Text = Helper.User.userSurname + "\n" + Helper.User.userName + "\n" + Helper.User.userPatronymic;
            if (user.userRole != User.UserRole.Администратор)
            {
                ButtonInsertProduct.Enabled = false;
                ButtonInsertProduct.Visible = false;
                ButtonUpdateProduct.Enabled = false;
                ButtonUpdateProduct.Visible = false;
            }
            DisplaySources();
            product = SQLHelper.GetOneRow("*", "[Product]", "[ProductArticleNumber]", article);
            TextBoxArticle.Text = product[0];
            TextBoxNameProduct.Text = product[1];
            SelectItem(CBManufacturer, int.Parse(product[6]));
            SelectItem(CBCategory, int.Parse(product[4]));
            TextBoxCost.Text = product[8];
            TextBoxDiscount.Text = product[9];
            TextBoxQuantity.Text = product[11];
            SelectItem(CBUnit, int.Parse(product[2]));
            SelectItem(CBProvider, int.Parse(product[7]));
            TextBoxDescription.Text = product[3];
            MemoryStream ms = SQLHelper.GetImageProduct(product[0]);
            try
            {
                Image image = Image.FromStream(ms);
                PictureBoxProduct.Image = image;
            }
            catch
            {
                PictureBoxProduct.Image = Resources.image;
            }
            TextBoxArticle.Enabled = false;

        }

        public void DisplaySources()
        {
            CBManufacturer.DataSource = SQLHelper.GetSource("[Manufacturer]");
            CBManufacturer.DisplayMember = "ManufacturerName";
            CBUnit.DataSource = SQLHelper.GetSource("[Unit]");
            CBUnit.DisplayMember = "UnitName";
            CBCategory.DataSource = SQLHelper.GetSource("[Category]");
            CBCategory.DisplayMember = "UnitName";
            CBProvider.DataSource = SQLHelper.GetSource("[Provider]");
            CBProvider.DisplayMember = "ProviderName";
        }

        public int GetID(DataTable table, ComboBox CB, string selecting)
        {
            DataRowView drv = (DataRowView)CB.SelectedItem;
            string check = drv[selecting].ToString();
            foreach(DataRow rows in table.Rows)
            {
                if (rows[1].ToString() == check)
                {
                    return int.Parse(rows[0].ToString());
                }
            }
            return -1;
        }

        public void SelectItem(ComboBox CB, int id)
        {
            int num = 0;
            DataTable table = (DataTable) CB.DataSource;
            foreach(DataRow rows in table.Rows)
            {
                if (int.Parse(rows[0].ToString()) == id)
                    CB.SelectedIndex = num;
                num++;
            }
        }


        private void ButTempExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Product CheckValidate()
        {
            int discount = -1;
            if (String.IsNullOrWhiteSpace(TextBoxArticle.Text))
                return null;
            if (String.IsNullOrEmpty(TextBoxNameProduct.Text))
                return null;
            if (String.IsNullOrEmpty(TextBoxCost.Text))
                return null;
            if (String.IsNullOrEmpty(TextBoxDescription.Text))
                return null;
            if (String.IsNullOrEmpty(TextBoxQuantity.Text))
                return null;
            if (String.IsNullOrEmpty(TextBoxDescription.Text))
                return null;
            if (String.IsNullOrEmpty(TextBoxDiscount.Text))
                discount = 0;
            int manufacturerID = GetID((DataTable)CBManufacturer.DataSource, CBManufacturer, "ManufacturerName");
            int unitID = GetID((DataTable)CBUnit.DataSource, CBUnit, "UnitName");
            int categoryID = GetID((DataTable)CBCategory.DataSource, CBCategory, "UnitName");
            int providerID = GetID((DataTable)CBProvider.DataSource, CBProvider, "ProviderName");

            if (manufacturerID < 0 || unitID < 0 || categoryID < 0 || providerID < 0)
            {
                return null;
            }
            try
            {
                double cost = Convert.ToDouble(TextBoxCost.Text);
                if (cost <= 0)
                    return null;
                int dotnum = TextBoxCost.Text.IndexOf(',');
                if (dotnum != -1 && TextBoxCost.Text.Length - dotnum - 1 > 2)
                    return null;
                if (discount != 0)
                {
                    discount = Convert.ToInt32(TextBoxDiscount.Text);
                    if (discount < 0 || discount >= 100)
                        return null;
                }
                int quantity = Convert.ToInt32(TextBoxQuantity.Text);
                if (quantity <= 0)
                    return null;
            }
            catch
            {
                return null;
            }
            Product product = new Product(TextBoxArticle.Text, TextBoxNameProduct.Text, unitID, TextBoxDescription.Text,
                categoryID, manufacturerID, providerID, Convert.ToDouble(TextBoxCost.Text), discount, discount, Convert.ToInt32(TextBoxQuantity.Text));
            return product;
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            Product product = CheckValidate();
            if (product is null)
                return;
            if (PictureBoxProduct.Image != Resources.image)
                product.InsertImage(product, PictureBoxProduct.Image);
            try
            {
                SQLHelper.InsertProduct(product);
            }
            catch
            {
                return;
            }
        }

        private void ButtonAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = dialog.FileName;
                PictureBoxProduct.Image = Image.FromFile(filepath);
            }
        }

        private void ButtonCancelImage_Click(object sender, EventArgs e)
        {
            PictureBoxProduct.Image = Resources.image;
        }

        private void ButtonUpdateProduct_Click(object sender, EventArgs e)
        {
            Product product = CheckValidate();
            if (product is null)
                return;
            if (PictureBoxProduct.Image != Resources.image)
                product.InsertImage(product, PictureBoxProduct.Image);
            try
            {
                SQLHelper.UpdateProduct(product);
            }
            catch
            {
                return;
            }
        }

        private void FormChangeProduct_Load(object sender, EventArgs e)
        {
            
            this.TableLayPanTempUp.BackColor = Color.FromArgb(255, 204, 153);
            this.TableLayPanTempDown.BackColor = Color.FromArgb(255, 204, 153);
        }

        private void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            string[] order = SQLHelper.GetOneRow("*", "[OrderProduct]", "[ProductArticleNumber]", product[0]);
            if (order.Length == 0)
            {
                SQLHelper.DeleteFromTable("[Product]", "[ProductArticleNumber]", product[0]);
                this.Close();
            }
            
        }
    }
}
