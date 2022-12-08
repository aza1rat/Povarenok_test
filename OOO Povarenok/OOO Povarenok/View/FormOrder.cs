using Microsoft.Office.Interop.Word;
using OOO_Povarenok.Properties;
using OOO_Povarenok.TradeDataSetTableAdapters;
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
using System.Xml;
using Word = Microsoft.Office.Interop.Word;

namespace OOO_Povarenok
{
    public partial class FormOrder : Form
    {
        ProductTableAdapter1 productAdapter = new ProductTableAdapter1();
        private double productsCost;
        private double productsCostWithDiscount;
        public FormOrder()
        {
            InitializeComponent();
        }

        private void DGWOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewCell clickedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (clickedCell is DataGridViewButtonCell)
            {
                string article = DGWOrder.Rows[e.RowIndex].Cells[0].Tag.ToString();
                DeleteItem(article);
                FormOrder_Load(null, null);
            }
        }

        public void Itog()
        {
            int positionsCount = Helper.CurrentOrder.Count;
            int productsCount = 0;
            double productsCost = 0;
            double productsCostWithDiscount = 0;
            foreach (OrderProduct order in Helper.CurrentOrder)
            {
                DataRow product = productAdapter.GetDataBy(order.articleProduct).Rows[0];
                productsCount += order.count;
                double cost = Convert.ToDouble((decimal)product["Cost"]);
                double discount = Convert.ToDouble(product["DiscountAmount"]);
                productsCostWithDiscount += (cost - (cost / 100 * discount)) * order.count;
                productsCost += cost * order.count;
            }
            RTextBoxDescOrder.Text = "";
            RTextBoxDescOrder.Text += "Позиций в заказе: " + positionsCount + Environment.NewLine;
            RTextBoxDescOrder.Text += "Всего товаров: " + productsCount + Environment.NewLine;
            if (productsCostWithDiscount != productsCost)
            {
                RTextBoxDescOrder.Text += "Общая сумма за весь заказ: " + productsCost + Environment.NewLine;
                RTextBoxDescOrder.Text += "Общая сумма скидки: " + (productsCost - productsCostWithDiscount).ToString("F2") + Environment.NewLine;
            }
            RTextBoxDescOrder.Text += "Всего: " + productsCostWithDiscount.ToString("F2") + Environment.NewLine;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            this.LabelUser.Text = Helper.User.userSurname + "\n" + Helper.User.userName + "\n" + Helper.User.userPatronymic;
            ButtonCoupon.Enabled = false;
            if (Helper.User.userRole == User.UserRole.Менеджер)
                LabelClient.Text = "";
            else
                LabelClient.Text = Helper.User.userSurname + " " + Helper.User.userName + " " +
                    "" + Helper.User.userPatronymic;
            DGWOrder.Rows.Clear();
            PickupPointTableAdapter pointAdapter = new PickupPointTableAdapter();
            CBDelivery.DataSource = pointAdapter.GetData();
            CBDelivery.DisplayMember = "PickupPointAddress";
            if (Helper.PointAdress is null)
            {
                CBDelivery.SelectedIndex = 0;
            }
            else
            {
                foreach (DataRow address in pointAdapter.GetData().Rows)
                {
                    if (address["PickupPointAddress"].ToString() == Helper.PointAdress)
                    {
                        CBDelivery.SelectedIndex = Convert.ToInt32(address["PickupPointID"]) - 1;
                        break;
                    }
                }
            }
            int positionsCount = Helper.CurrentOrder.Count;
            int productsCount = 0;
            productsCost = 0;
            productsCostWithDiscount = 0;
            foreach (OrderProduct order in Helper.CurrentOrder)
            {
                int id = DGWOrder.Rows.Add();
                DGWOrder.Rows[id].Cells[0].Value = order.articleProduct;
                DataRow product = productAdapter.GetDataBy(order.articleProduct).Rows[0];
                DGWOrder.Rows[id].Cells[0].Tag = (string)product["ArticleNumber"];
                DGWOrder.Rows[id].Cells[0].Value = (string)product["Type"];
                DGWOrder.Rows[id].Cells[1].Value = order.count;
                productsCount += order.count;
                double cost = Convert.ToDouble((decimal)product["Cost"]);
                double discount = Convert.ToDouble((decimal)product["DiscountAmount"]);
                productsCostWithDiscount += (cost - (cost / 100 * discount)) * order.count;
                productsCost += cost * order.count;


            }
            RTextBoxDescOrder.Text = "";
            RTextBoxDescOrder.Text += "Позиций в заказе: " + positionsCount + Environment.NewLine;
            RTextBoxDescOrder.Text += "Всего товаров: " + productsCount + Environment.NewLine;
            if (productsCostWithDiscount != productsCost)
            {
                RTextBoxDescOrder.Text += "Общая сумма за весь заказ: " + productsCost + Environment.NewLine;
                RTextBoxDescOrder.Text += "Общая сумма скидки: " + (productsCost - productsCostWithDiscount).ToString("F2") + Environment.NewLine;
            }
            RTextBoxDescOrder.Text += "Всего: " + productsCostWithDiscount.ToString("F2") + Environment.NewLine;

            if (DGWOrder.Rows.Count == 0)
            {
                ClearComponents();
                return;
            }
            DGWOrder.CurrentCell = DGWOrder.Rows[0].Cells[1];
            DGWOrder.BeginEdit(true);
        }

        private void FormOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.PointAdress = CBDelivery.Text;
        }

        public void ClearComponents()
        {
            PicBoxOrderPhoto.Image = null;
            RTextBoxDescOrder.Clear();
            RTextBoxDescProduct.Clear();

        }

        private void DGWOrder_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (DGWOrder.Rows[e.RowIndex].Cells[0].Tag == null)
            {
                ClearComponents();
                return;
            }
            string article = DGWOrder.Rows[e.RowIndex].Cells[0].Tag.ToString();
            DataRow product = productAdapter.GetDataBy(article).Rows[0];
            RTextBoxDescProduct.Text = "";
            RTextBoxDescProduct.Text += "Название: " + (string)product["Type"] + Environment.NewLine;
            RTextBoxDescProduct.Text += "Описание: " + (string)product["Description"] + Environment.NewLine;
            RTextBoxDescProduct.Text += "Категория: " + (string)product["Category"] + Environment.NewLine;
            RTextBoxDescProduct.Text += "Производитель: " + (string)product["Manufacturer"] + Environment.NewLine;
            RTextBoxDescProduct.Text += "Поставщик: " + (string)product["Provider"] + Environment.NewLine;
            RTextBoxDescProduct.Text += "Цена без скидки: " + Convert.ToDouble((decimal)product["Cost"]) + Environment.NewLine;
            RTextBoxDescProduct.Text += "Скидка: " + Convert.ToDouble((decimal)product["DiscountAmount"]) + Environment.NewLine;
            try
            {
                MemoryStream ms = new MemoryStream((byte[])product["Photo"]);
                Image image = Image.FromStream(ms);
                PicBoxOrderPhoto.Image = image;
            }
            catch (Exception)
            {
                PicBoxOrderPhoto.Image = Resources.image;
            }
        }

        public int GetCount(string article)
        {
            for (int i = 0; i < Helper.CurrentOrder.Count; i++)
            {
                if (Helper.CurrentOrder[i].articleProduct == article)
                    return Helper.CurrentOrder[i].count;
            }
            return -1;
        }

        public void SetCount(string article, int count)
        {
            for (int i = 0; i < Helper.CurrentOrder.Count; i++)
            {
                if (Helper.CurrentOrder[i].articleProduct == article)
                {
                    Helper.CurrentOrder[i].count = count;
                    break;
                }
                    
            }
        }

        public void DeleteItem(string article)
        {
            for (int i = 0; i < Helper.CurrentOrder.Count; i++)
            {
                if (Helper.CurrentOrder[i].articleProduct == article)
                {
                    Helper.CurrentOrder.RemoveAt(i);
                    break;
                }
            }
        }

        private void DGWOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (DGWOrder.Rows[e.RowIndex].Cells[0].Tag == null)
                return;
            string article = DGWOrder.Rows[e.RowIndex].Cells[0].Tag.ToString();
            if (e.ColumnIndex == 1)
            {
                int count;
                try
                {
                    count = Convert.ToInt32(DGWOrder.Rows[e.RowIndex].Cells[1].Value);
                    if (count < 0)
                    {
                        DGWOrder.Rows[e.RowIndex].Cells[1].Value = GetCount(article);
                        return;
                    }
                    if (count == 0)
                    {
                        DeleteItem(article);
                        FormOrder_Load(null, null);
                        return;
                    }
                    SetCount(article, count);
                    Itog();

                }
                catch
                {
                    DGWOrder.Rows[e.RowIndex].Cells[1].Value = GetCount(article);
                    return;
                }
            }
        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SQLHelper.InsertOrder(CBDelivery.SelectedIndex + 1);
                ButtonCoupon.Enabled = true;
                
            }
            catch
            {

            }
        }

        private void SetCoupon ()
        {
            
            Word.Application wordApp;
            Word.Document wordDoc;
            Word.Paragraph wordPar;
            Word.Range wordRange;
            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = false;
            }
            catch
            {
                MessageBox.Show("Товарный чек в Word создать не удалось");
                return;
            }

            wordDoc = wordApp.Documents.Add();
            wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
            wordDoc.Content.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Word.Paragraph paragraphPicter = wordDoc.Paragraphs.Add();
            Word.Range rangePicter = paragraphPicter.Range;
            wordDoc.Content.Font.Size = 14;
            Word.InlineShape wordPicter = wordDoc.InlineShapes.AddPicture(Environment.CurrentDirectory + "\\logo.png", Range: wordApp.Selection.Range);
            wordPicter.Width = 70;
            wordPicter.Height = 70;
            rangePicter.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            rangePicter.InsertParagraphAfter();
            string[] list = SQLHelper.GetOneRow("*", "[Order]", "[OrderID]", OrderProduct.orderId.ToString());
            Word.Paragraph paragraphTitle = wordDoc.Paragraphs.Add();
            Word.Range rangeTitle = paragraphTitle.Range;
            rangeTitle.Text = " Номер заказа: №" + list[6];
            rangeTitle.Font.Bold = 1;
            rangeTitle.Font.Size = 20;

            rangeTitle.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            rangeTitle.InsertParagraphAfter();

            Word.Paragraph summa = wordDoc.Paragraphs.Add();
            Word.Range rangesumma = summa.Range;
            rangesumma.Text += "Дата заказа: " + list[1];
            rangesumma.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            rangesumma.InsertParagraphAfter();


            wordPar = (Word.Paragraph)wordDoc.Paragraphs[1];
            wordPar = wordDoc.Paragraphs.Add();
            wordRange = wordPar.Range;


            Word.Table wordTable;
            wordTable = wordDoc.Tables.Add(wordRange, DGWOrder.RowCount + 1, 2);
            wordTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            wordTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;


            Word.Range cellRange;
            cellRange = wordTable.Cell(1, 1).Range;
            cellRange.Text = "Товар";
            cellRange = wordTable.Cell(1, 2).Range;
            cellRange.Text = "Количество";
            for (int i = 0; i < Helper.CurrentOrder.Count; i++)
            {
                DataRow productTable = productAdapter.GetDataBy(Helper.CurrentOrder[i].articleProduct).Rows[0];
                cellRange = wordTable.Cell(i + 2, 1).Range;
                cellRange.Text = (string)productTable["Type"];

                cellRange = wordTable.Cell(i + 2, 2).Range;
                cellRange.Text = Helper.CurrentOrder[i].count.ToString();
            }

            Word.Paragraph paragraphtext = wordDoc.Paragraphs.Add();
            Word.Range rangetext = paragraphtext.Range;
            rangetext.Text = "Сумма заказа: " + productsCost + Environment.NewLine;
            rangetext.Text += "Сумма заказа (со скидкой): " + productsCostWithDiscount + Environment.NewLine;
            rangetext.Text += "Пункт выдачи: " + CBDelivery.Text + Environment.NewLine;
            rangetext.Text += "Дата получение: " + list[2];
            rangetext.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            rangetext.InsertParagraphAfter();

            ///
            wordDoc.Saved = true;

            string pathDoc = Environment.CurrentDirectory + "\\Word\\" + "test.pdf";
            wordDoc.SaveAs(pathDoc + ".docx");

            wordDoc.SaveAs(pathDoc + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
            wordDoc.Close(true, null, null);
            wordDoc = null;
            MessageBox.Show("Талон создан");
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wordApp);

        }

        private void ButtonCoupon_Click(object sender, EventArgs e)
        {
            SetCoupon();
        }

        private void ButTempExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
