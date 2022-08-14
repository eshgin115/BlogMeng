using ConsoleApp1.DataBase.Models;
using ConsoleApp1.DataBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Repository
{
    public class UserRepo : Repo<User, int>
    {
        private static int _idcounter;

        public static int IDCounter
        {
            get
            {
                _idcounter++;
                return _idcounter;
            }
        }
        static UserRepo()
        {
            SeedUsers();
        }

        public static void SeedUsers()
        {
            DbContext.Add(new Admin("Eshqin", "Faracov", "Eshqin115@gmail.com", "123321"));
            DbContext.Add(new User("ceyhun", "hacizada", "ceyhunhaci@gmail.com", "123321"));
            DbContext.Add(new User("Ali", "Aliyev", "Ali@gmail.com", "123321"));
        }
        public static bool IsEmailConfirmation(string email)
        {
            foreach (User user in DbContext)
            {
                if (user.Email == email)
                {
                    return false;
                }
            }
            return true;
        }
        public static User Add(string name,
           string lastName,
           string email,
           string password)
        {
            User user = new User(name, lastName, email, password);
            DbContext.Add(user);
            return user;
        }
        public static User IsCheckEmailAndPassword(string email, string pass)
        {
            foreach (User user in DbContext)
            {
                if (user.Email == email && user.Password == pass)
                {
                    return user;
                }
            }
            return null;
        }
        public static User GetUserByEmail(string email)
        {
            foreach (User user in DbContext)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }


    }
}
