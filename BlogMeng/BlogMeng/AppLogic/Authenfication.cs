
using ConsoleApp1.AppLogic.Validations;
using ConsoleApp1.DataBase.Models;
using ConsoleApp1.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AppLogic
{
    public class Authenfication
    {
        public static void Register()
        {
            Console.WriteLine();
            string firstName = GetName();
            string lastName = GetLastName();
            string email = GetEmail();
            string password = GetPassword();
            Console.WriteLine();
            User user = UserRepo.Add(firstName, lastName, email, password);
            Console.WriteLine("User aded the system" + user.GetInfo());
            Console.WriteLine("You successfully registered, now you can login with your new account!");
        }
        public static void Login()
        {

            Console.WriteLine();
            Console.WriteLine("Please enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter Password");
            string password = Console.ReadLine();
            User currentUser = UserRepo.IsCheckEmailAndPassword(email, password);
            if (currentUser == null)
            {
                Console.WriteLine("User is not found in system");
            }
            else if (currentUser is Admin)
            {
                DashBoard.AdminPanel(currentUser);
            }
            else if (currentUser is User)
            {
                DashBoard.UserPanel(currentUser);
            }





        }
        public static string GetName()
        {
            Console.Write("Please add User's name : ");
            string firstName = Console.ReadLine();
            while (!UserValidation.IsCheckName(firstName))
            {
                Console.Write("Please Enter correct UsersName : ");
                firstName = Console.ReadLine();
            }
            return firstName;
        }
        public static string GetLastName()
        {
            Console.Write("Please add User's LastName : ");
            string lastName = Console.ReadLine();
            while (!UserValidation.IsCheckLastName(lastName))
            {
                Console.Write("Please Enter correct LastName : ");
                lastName = Console.ReadLine();
            }
            return lastName;
        }
        public static string GetEmail()
        {
            Console.Write("Please add User's email : ");
            string email = Console.ReadLine();
            while (!UserValidation.IsCheckEmail(email))
            {
                Console.Write("Please Enter correct email : ");
                email = Console.ReadLine();
            }
            return email;
        }
        public static string GetPassword()
        {
            Console.Write("Please add User's password : ");
            string password = Console.ReadLine();
            Console.WriteLine("Please enter confirmPassword");
            string confirmPass = Console.ReadLine();
            if (password == confirmPass)
            {
                while (!UserValidation.IsCheckPass(password))
                {
                    Console.Write("Please Enter correct password : ");
                    password = Console.ReadLine();
                }
                return password;
            }
            return null;
        }
        public static string GetNameBlog()
        {
            Console.WriteLine("Please enter NameBlog : ");
            string NameBlog = Console.ReadLine();
            while (!CommoonValidations.Count(NameBlog, number => number > 10 && number < 35))
            {
                Console.WriteLine("Please enter correct NameBlog : ");
                NameBlog = Console.ReadLine();
            }
            return NameBlog;
        }
        public static string GetTextBlog()
        {
            Console.WriteLine("Please enter text : ");
            string text = Console.ReadLine();
            while (!CommoonValidations.Count(text, number => number > 20 && number < 45))
            {
                Console.WriteLine("Please enter correct text : ");
                text = Console.ReadLine();
            }
            return text;
        }
        public static string GetThisComment()
        {
            Console.WriteLine("Please enter thisComment : ");
            string thisComment = Console.ReadLine();
            while (!CommoonValidations.Count(thisComment, number => number > 10 && number < 35))
            {
                Console.WriteLine("Please enter correct thisComment : ");
                thisComment = Console.ReadLine();
            }
            return thisComment;
        }
    }
}
