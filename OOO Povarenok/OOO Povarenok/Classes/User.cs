using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Povarenok
{
    public class User
    {
        public enum UserRole
        {
            Клиент,
            Менеджер,
            Администратор
        }
        public int id;
        public string userSurname;
        public string userName;
        public string userPatronymic;
        public string userLogin;
        public string userPassword;
        public UserRole userRole;
        

        public User (int id, string surname, string name, string patronymic, string login, string password, UserRole userRole)
        {
            this.id = id;
            userSurname = surname;
            userName = name;
            userPatronymic = patronymic;
            userLogin = login;
            userPassword = password;
            this.userRole = userRole;
        }

        public static UserRole GetUser(int id)
        {
            switch(id)
            {
                case 1: return UserRole.Клиент;
                case 2: return UserRole.Менеджер;
                case 3: return UserRole.Администратор;
            }
            return UserRole.Клиент;
        }
    }
}
