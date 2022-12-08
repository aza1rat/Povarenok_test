using System.Collections.Generic;
using System.Windows.Forms;

namespace OOO_Povarenok
{
    class Helper
    {
        //public static string ConnectionString = @"Data Source = sql.vm; Initial Catalog = KashitsinArtyom493Trade; Persist Security Info = True; User ID =  iam01; Password = password;";
        public static string ConnectionString = @"Data Source = LAPTOP-7SNQ0UF8\SQLEXPRESS; Initial Catalog = Trade; Integrated Security = True;";
        public static User User;
        public static List<OrderProduct> CurrentOrder = new List<OrderProduct>();
        public static string PointAdress;
        /// <summary>
        /// Отображение сообщения пользователю
        /// </summary>
        /// <param name="message"></param>
        /// <param name="header"></param>
        /// <param name="icon"></param>
        public static void ShowMessage(string message, string header, MessageBoxIcon icon)
        {
            MessageBox.Show(message, header, MessageBoxButtons.OK, icon);
        }
    }
}
