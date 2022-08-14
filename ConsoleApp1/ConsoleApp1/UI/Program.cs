using System;

namespace ConsoleApp1.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/Register");
            Console.WriteLine("/Login");
            Console.WriteLine("/exit");
            Console.WriteLine("/show-blogs-with-comments");
            Console.WriteLine("/show-filtered-blogs-with-comments");
            Console.WriteLine("/find-blog-by-code");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter command: ");
                string command = Console.ReadLine();
                if (command == "/Register")
                {
                    Authenfication.Register();
                }
                else if (command == "/Login")
                {
                    Authenfication.Login();
                }
                else if (command == "/exit")
                {
                    break;
                }
                else if (command == "/show-blogs-with-comments")
                {
                    ServicBlog.ShowBlog();
                }
                else if (command == "/show-filtered-blogs-with-comments")
                {
                    ServicBlog.ShowFilteredBlog();
                }
                else if (command == "/find-blog-by-code")
                {
                    ServicBlog.FindBlogByCode();
                }
                else
                {
                    Console.WriteLine("Command is not correct");
                }
            } 
        }
    }
}
