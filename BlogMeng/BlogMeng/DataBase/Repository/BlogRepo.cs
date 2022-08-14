using ConsoleApp1.DataBase.Models;
using ConsoleApp1.DataBase.Models.Enums;
using ConsoleApp1.DataBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Repository
{


    public class BlogRepo : Repo<Blog, string>
    {
        static Random randomID = new Random();

        private static string _code;


        public static string RandomCode
        {
            get
            {
                do
                {
                    _code = "BL" + randomID.Next(1000, 100000);
                }
                while (Exsits(_code));
                {
                    return _code;
                }
            }
        }
        public static List<Blog> Get(int id)
        {
            List<Blog> myBlogs = new List<Blog>();
            foreach (Blog blog in DbContext)
            {
                if (blog.FromUser.Id == id)
                {
                    myBlogs.Add(blog);
                }
            }
            return myBlogs;
        }

        public static List<Blog> GetSendend()
        {
            List<Blog> sendedBlog = new List<Blog>();
            foreach (Blog blog in DbContext)
            {
                if (blog.BlogStatus == BlogStatus.Sended)
                {
                    sendedBlog.Add(blog);
                }
            }
            return sendedBlog;
        }

        public static Blog Approved(string blogKod)
        {

            foreach (Blog blog in DbContext)
            {
                if (blog.Id == blogKod && blog.BlogStatus == BlogStatus.Accepted)
                {
                    return blog;
                }
            }
            return null;
        }
        public static bool Exsits(string blogKod)
        {
            foreach (Blog blog in DbContext)
            {
                if (blog.Id == blogKod)
                {
                    return true;
                }
            }
            return false;
        }

        static BlogRepo()
        {
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("Eshqin115@gmail.com"), "Revan", "Salam", BlogStatus.Sended, "BLCode"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("Eshqin115@gmail.com"), "odu", "Salam", BlogStatus.Accepted, "BLCode11"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("Eshqin115@gmail.com"), "budu", "Salam", BlogStatus.Rejected, "BLCode12141211"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("Ali@gmail.com"), "aliwka", "Salam", BlogStatus.Accepted, "BLCode12141212"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("Ali@gmail.com"), "codeali", "Salam", BlogStatus.Rejected, "BLCode1412431122"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("Ali@gmail.com"), "ali", "Salam", BlogStatus.Sended, "BLCode12121"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("ceyhunhaci@gmail.com"), "ceyhun", "Salam", BlogStatus.Sended, "BLCode412312122"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("ceyhunhaci@gmail.com"), "CEKA", "Salam", BlogStatus.Accepted, "BLCode212412123"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("ceyhunhaci@gmail.com"), "MYNAMECEYHUN", "Salam", BlogStatus.Rejected, "BLCode221412433"));
        }
    }
}
