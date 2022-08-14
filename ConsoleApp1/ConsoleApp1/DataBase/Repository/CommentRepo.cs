using ConsoleApp1.DataBase.Models;
using ConsoleApp1.DataBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Repository
{
    public class CoomentRepo : Repo<Comment, int>
    {
        public static void Delete(Blog blog)
        {
            foreach (Comment comment in DbContext)
            {
                if (comment.Blog == blog)
                {
                    DbContext.Remove(comment);
                }
            }
        }
        static CoomentRepo()
        {
            BlogRepo blogRepo = new BlogRepo();
            DbContext.Add(new Comment(UserRepo.GetUserByEmail("Eshqin115@gmail.com"), "Default comment", blogRepo.Get(c => c.Id == "BLCode11")));
            DbContext.Add(new Comment(UserRepo.GetUserByEmail("Ali@gmail.com"), "SALAM QAQA", blogRepo.Get(c => c.Id == "BLCode11")));
            DbContext.Add(new Comment(UserRepo.GetUserByEmail("ceyhunhaci@gmail.com"), "SALAM QAQA", blogRepo.Get(c => c.Id == "BLCode11")));

        }
    }
}
