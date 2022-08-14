using ConsoleApp1.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Models
{
    public class Blog : Entity<string>
    {

        public User FromUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public BlogStatus BlogStatus { get; set; }
        public DateTime CreatBlogCreateDate { get; set; } = DateTime.Now;

        public Blog(User user, string title, string content, BlogStatus blogStatus, string id = null)
        {

            FromUser = user;
            Title = title;
            Content = content;
            BlogStatus = blogStatus;
            if (id != null)
            {
                Id = id;
            }
            else
            {
                Id = BlogRepo.RandomCode;
            }
        }
        public string GetInfo()
        {
            return $"<BlogCreateDate : {CreatBlogCreateDate}>] [<blogCode : {Id}>] [<Title : {Title}>] [<Content : {Content}>] [<BlogStatus : {BlogStatus}>]";
        }
        public string GetInfoSended()
        {
            return $"[<PublishDate(dd.MM.yyyy) : {CreatBlogCreateDate}] [<BlogCode : {Id}>] [<BlogStatus> : {BlogStatus}] [<FirstName : {FromUser.Name}> <LastName : {FromUser.LastName}>] \n {Title} \n{Content}";
        }
    }
}
