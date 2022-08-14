using ConsoleApp1.DataBase.Models;
using ConsoleApp1.DataBase.Models.Enums;
using ConsoleApp1.DataBase.Repository;
using ConsoleApp1.DataBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AppLogic
{
    public class ServicBlog
    {
        public static BlogRepo BlogRepo = new BlogRepo();
        public static CoomentRepo basecomrepo = new CoomentRepo();
        public static void ShowBlog()
        {
            //Repo<Blog, string> blogRepo = new Repo<Blog, string>();
            //Repo<Comment, int> coomentRepo = new Repo<Comment, int>();


            List<Blog> blogs = BlogRepo.GetAll();
            int counnt = 1;
            foreach (Blog blog in blogs)
            {
                if (blog.BlogStatus == BlogStatus.Accepted)
                {
                    Console.WriteLine(blog.GetInfo());
                    List<Comment> comments = basecomrepo.GetAll();
                    foreach (Comment comment in comments)
                    {
                        if (comment.Blog == blog)
                        {

                            Console.WriteLine($"{counnt}" + comment.GetInfo());
                            counnt++;
                        }
                    }
                }
            }
        }
        public static void ShowFilteredBlog()
        {
            Repo<Blog, string> blogRepo = new Repo<Blog, string>();
            Repo<Comment, int> coomentRepo = new Repo<Comment, int>();
            Console.WriteLine("Title");
            Console.WriteLine("FirstName");
            string command = Console.ReadLine();
            if (command == "Title")
            {
                List<Blog> blogs = blogRepo.GetAll();
                Console.WriteLine("Enter title ");
                string title = Console.ReadLine();
                foreach (Blog blog in blogs)
                {
                    if (blog.BlogStatus == BlogStatus.Accepted && blog.Title.Contains(title))
                    {
                        Console.WriteLine(blog.GetInfo());
                    }
                }

            }
            else if (command == "FirstName")
            {
                List<Blog> blogs = blogRepo.GetAll();
                Console.WriteLine("Enter firsName ");
                string firsName = Console.ReadLine();
                foreach (Blog blog in blogs)
                {
                    if (blog.BlogStatus == BlogStatus.Accepted && blog.FromUser.Name.Contains(firsName))
                    {
                        Console.WriteLine(blog.GetInfo());
                    }
                }
            }

        }
        public static void FindBlogByCode()
        {
            Console.WriteLine("Please enter Code for Find blog");
            string code = Console.ReadLine();
            Blog blog = BlogRepo.Approved(code);
            if (blog == null)
            {
                Console.WriteLine("This blog is not found");
            }
            else
            {

                Console.WriteLine(blog.GetInfo());
            }

        }
    }
}
