using ConsoleApp1.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Models
{
    public class Comment : Entity<int>
    {
        public Blog Blog { get; set; }
        public User FromUser { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public Comment(User fromUser, string commentContent, Blog blog)
        {
            FromUser = fromUser;
            CommentContent = commentContent;
            Blog = blog;
        }
        public string GetInfo()
        {
            return $"[<CommentDate(dd.MM.yyyy) : {DateTimeCreated}>] [<FirstName : {FromUser.Name}> <LastName : {FromUser.LastName}>]  - <Content : {CommentContent}> ";
        }
    }
}
