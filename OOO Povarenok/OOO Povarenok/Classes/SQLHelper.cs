using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Common;
using System.IO;
using System.Data;
using System.Drawing.Imaging;
using OOO_Povarenok.TradeDataSetTableAdapters;

namespace OOO_Povarenok
{
    class SQLHelper
    {
        private static readonly SqlConnection connection = new SqlConnection(Helper.ConnectionString);

        /// <summary>
        /// Проверка подключения к БД
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
        {
            try
            {
                connection.Open();
            }
            catch (SqlException exception)
            {
                Helper.ShowMessage(exception.Message, "Ошибка при подключении", MessageBoxIcon.Error);
                return false;
            }
			catch (Exception)
			{
                Helper.ShowMessage("Произошла ошибка при подключении к базе данных", "Ошибка при подключении", MessageBoxIcon.Error);
				return false;
			}
            Helper.ShowMessage("Подключение к БД произошло успешно", "Подключение к БД", MessageBoxIcon.Information);
            return true;
        }
        /// <summary>
        /// Закрытие соединения с БД
        /// </summary>
        public static void CloseConnection()
        {
            connection.Close();
        }
        /// <summary>
        /// Получение ответа от БД в виде массива сток после операции SELECT с указанием таблиц, полей и условия
        /// </summary>
        /// <param name="selecting"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string[] GetOneRow(string selecting, string table, string column = "dflt", string value = "dflt")
        {
            string[] result = new string[0];
            SqlCommand command;
            if (column != "dflt")
            {
                command = new SqlCommand($"SELECT {selecting} FROM {table} WHERE {column} = @value", connection);
                command.Parameters.AddWithValue("@value", value);
            }
            else
            {
                command = new SqlCommand($"SELECT {selecting} FROM {table}", connection);
            }
            
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                result = new string[reader.FieldCount];
                reader.Read();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result[i] = reader[i].ToString();
                }
            }
            reader.Close();
            return result;
        }

        public static User GetUser(string column, string value)
        {
            User user = null;
            SqlCommand command = new SqlCommand($"SELECT * FROM [User] WHERE {column} = @value", connection);
            command.Parameters.AddWithValue("@value", value);
            SqlDataReader reader= command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                user = new User(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    User.GetUser(reader.GetInt32(6))
                    );
                    
            }
            reader.Close();
            return user;
        }

        public static DataTable GetSource(string table)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM {table}", connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public static void UpdateProduct(Product product)
        {
            SqlCommand command = new SqlCommand($"UPDATE [Product] SET " +
                $"[ProductType] = @type," +
                $"[ProductUnit] = @unit," +
                $"[ProductDescription] = @desc," +
                $"[ProductCategory] = @category," +
                $"[ProductPhoto] = @photo," +
                $"[ProductManufacturer] = @manufacturer," +
                $"[ProductProvider] = @provider," +
                $"[ProductCost] = @cost," +
                $"[ProductDiscountAmount] = @discount," +
                $"[ProductMaxDiscount] = @discount," +
                $"[ProductQuantityInStock] = @quantity " +
                $"WHERE [ProductArticleNumber] = @article", connection);
            command.Parameters.AddWithValue("@article", product.productArticle);
            command.Parameters.AddWithValue("@type", product.productType);
            command.Parameters.AddWithValue("@unit", product.productUnit);
            command.Parameters.AddWithValue("@desc", product.productDescription);
            command.Parameters.AddWithValue("@category", product.productCategory);
            if (product.productPhoto != null)
            {
                MemoryStream ms = new MemoryStream();
                product.productPhoto.Save(ms, ImageFormat.Jpeg);
                command.Parameters.AddWithValue("@photo", ms.ToArray());
            }
            else
            {
                command.Parameters.AddWithValue("@photo", null);
            }
            command.Parameters.AddWithValue("@manufacturer", product.productManufacturer);
            command.Parameters.AddWithValue("@provider", product.productProvider);
            command.Parameters.AddWithValue("@cost", product.productCost);
            command.Parameters.AddWithValue("@discount", product.productDiscount);
            command.Parameters.AddWithValue("@maxdiscount", product.productMaxDiscount);
            command.Parameters.AddWithValue("@quantity", product.productQuantity);
            command.ExecuteNonQuery();
        }

        public static void InsertProduct(Product product)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO [Product] VALUES " +
                $"(@article,@type,@unit,@desc,@category,@photo,@manufacturer,@provider,@cost,@discount,@maxdiscount,@quantity)"
                ,connection);
            command.Parameters.AddWithValue("@article", product.productArticle);
            command.Parameters.AddWithValue("@type", product.productType);
            command.Parameters.AddWithValue("@unit", product.productUnit);
            command.Parameters.AddWithValue("@desc", product.productDescription);
            command.Parameters.AddWithValue("@category", product.productCategory);
            if (product.productPhoto != null)
            {
                MemoryStream ms = new MemoryStream();
                product.productPhoto.Save(ms, ImageFormat.Jpeg);
                command.Parameters.AddWithValue("@photo", ms.ToArray());
            }
            else
            {
                command.Parameters.AddWithValue("@photo", null);
            }
            command.Parameters.AddWithValue("@manufacturer", product.productManufacturer);
            command.Parameters.AddWithValue("@provider", product.productProvider);
            command.Parameters.AddWithValue("@cost", product.productCost);
            command.Parameters.AddWithValue("@discount", product.productDiscount);
            command.Parameters.AddWithValue("@maxdiscount", product.productMaxDiscount);
            command.Parameters.AddWithValue("@quantity", product.productQuantity);
            command.ExecuteNonQuery();
        }


        public static MemoryStream GetImageProduct(string art)
        {
            MemoryStream ms = new MemoryStream();
            SqlCommand command = new SqlCommand($"SELECT [ProductPhoto] FROM [Product] WHERE [ProductArticleNumber] = '{art}'", connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                try
                {
                    ms = new MemoryStream((byte[])reader.GetSqlBinary(0));
                }
                catch
                {

                }
                
            }
            reader.Close();
            return ms;
        }

        public static int GetMaxId(string table, string selector)
        {
            int maxId = 0;
            SqlCommand command = new SqlCommand($"SELECT MAX({selector}) FROM {table}",connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                maxId = (int)reader[0];
            }
            reader.Close();
            return maxId;
        }

        public static void InsertOrder(int pickup)
        {
            ProductTableAdapter1 productAdapter = new ProductTableAdapter1();
            Random random = new Random();
            int orderCode = 0;
            SqlCommand command;
            SqlDataReader reader;
            DateTime timeNow = DateTime.Now;
            DateTime timeOrder = DateTime.Now;
            timeOrder.AddDays(3);
            do
            {
                orderCode = random.Next(100, 1000);
                command = new SqlCommand($"SELECT OrderID FROM [Order] WHERE OrderCode = {orderCode}",connection);
                reader = command.ExecuteReader();
            }
            while (reader.HasRows);
            reader.Close();
            foreach (OrderProduct order in Helper.CurrentOrder)
            {
                DataRow product = productAdapter.GetDataBy(order.articleProduct).Rows[0];
                int quantityInStock = (int)product["QuantityInStock"];
                if (quantityInStock - order.count < 3)
                {
                    timeOrder.AddDays(3);
                    break;
                }
            }
            int orderId = GetMaxId("[Order]", "[OrderID]") + 1;
            OrderProduct.orderId = orderId;
            if (Helper.User.userRole == User.UserRole.Клиент)
            {
                command = new SqlCommand($"INSERT INTO [Order] VALUES (@id,@date,@deliverydate,@pickup,@status,@client,@code)",connection);
                command.Parameters.AddWithValue("@client", Helper.User.id);
            }
            else
            {
                command = new SqlCommand($"INSERT INTO [Order] (OrderID,OrderDate,OrderDeliveryDate,OrderPickupPointID,OrderStatusID,OrderCode) " +
                    $"VALUES (@id,@date,@deliverydate,@pickup,@status,@code)", connection);
            }
            command.Parameters.AddWithValue("@id", orderId);
            command.Parameters.AddWithValue("@date", timeNow);
            command.Parameters.AddWithValue("@deliverydate", timeOrder);
            command.Parameters.AddWithValue("@pickup", pickup);
            command.Parameters.AddWithValue("@status", 2);
            command.Parameters.AddWithValue("@code", orderCode);
            command.ExecuteNonQuery();
            command = new SqlCommand("INSERT INTO [OrderProduct] VALUES (@id,@article,@count)", connection);
            command.Parameters.AddWithValue("@id", orderId);
            command.Parameters.AddWithValue("@article", null);
            command.Parameters.AddWithValue("@count", null);
            foreach(OrderProduct product in Helper.CurrentOrder)
            {
                command.Parameters["@article"].Value = product.articleProduct;
                command.Parameters["@count"].Value = product.count;
                command.ExecuteNonQuery();
            }

        }

        public static void DeleteFromTable(string table, string param, string value)
        {
            SqlCommand command = new SqlCommand($"DELETE FROM {table} WHERE {param} = @value", connection);
            command.Parameters.AddWithValue("@value", value);
            command.ExecuteNonQuery();
        }

        public static List<string[]> GetRows(string selecting, string table, string param)
        {
            List<string[]> rows = new List<string[]>();
            string[] result;
            SqlCommand command = new SqlCommand($"SELECT {selecting} FROM {table} {param}", connection);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                
                while(reader.Read())
                {
                    result = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result[i] = reader[i].ToString();
                    }
                    rows.Add(result);
                }
                
            }
            reader.Close();
            return rows;
        }
       


    }


}
