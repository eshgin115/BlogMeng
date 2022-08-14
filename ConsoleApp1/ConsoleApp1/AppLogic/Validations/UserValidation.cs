using ConsoleApp1.DataBase.Models;
using ConsoleApp1.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.AppLogic.Validations
{
    public class UserValidation
    {
        public static List<User> users = new List<User>();
        public static bool IsCheckName(string name)
        {
            if (Regex.IsMatch(name, @"^[A-Z]{1,1}[a-zA-Z]{3,30}"))
            {
                return true;
            }
            Console.WriteLine("Name Is not correcr");
            return false;
        }
        public static bool IsCheckLastName(string lastName)
        {
            if (Regex.IsMatch(lastName, @"^[A-Z]{1,1}[a-zA-Z]{4,29}"))
            {
                return true;
            }
            Console.WriteLine("LastName is not correct");
            return false;
        }
        public static bool IsCheckEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9]{10,20}@code\.edu\.az") && UserRepo.IsEmailConfirmation(email))
            {
                return true;
            }
            Console.WriteLine("Your email is not correct or already exists");
            return false;
        }
        public static bool IsCheckPass(string pass)
        {
            if (Regex.IsMatch(pass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"))
            {
                return true;
            }
            Console.WriteLine("your password is not correct");
            return false;

        }
    }
}
