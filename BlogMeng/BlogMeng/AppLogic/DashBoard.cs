using ConsoleApp1.DataBase.Models;
using ConsoleApp1.DataBase.Models.Enums;
using ConsoleApp1.DataBase.Repository;
using ConsoleApp1.DataBase.Repository.Common;
using ConsoleApp1.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AppLogic
{
    public static class DashBoard
    {
        public static User CurrentUser { get; set; }
        public static void AdminPanel(User user)
        {
            Repo<User, int> UserRepo = new Repo<User, int>();
            BlogRepo blogRepo = new BlogRepo();
            InboxRepo inboxRepo = new InboxRepo();
            CurrentUser = user;
            Console.WriteLine($"Welcome to your account dear admin,  <FirstName : {user.Name} > <LastName : {user.LastName}> <Email : {user.Email}>!");
            Console.WriteLine("/show-users");
            Console.WriteLine("/show-admins");
            Console.WriteLine("/show-auditing-blogs");
            Console.WriteLine("/approve-blog");
            Console.WriteLine("/reject-blog");
            Console.WriteLine("/logout");
            while (true)
            {

                string command = Console.ReadLine();
                if (command == "/show-users")
                {
                    List<User> users = UserRepo.GetAll();
                    foreach (User user1 in users)
                    {
                        if (user1 is not Admin)
                        {
                            Console.WriteLine(user1.GetInfo());
                        }
                    }
                }
                else if (command == "/show-admins")
                {
                    List<User> users = UserRepo.GetAll();
                    foreach (User user1 in users)
                    {
                        if (user1 is Admin)
                        {
                            Console.WriteLine(user1.GetInfo());
                        }
                    }
                }
                else if (command == "/show-auditing-blogs")
                {
                    foreach (Blog blog in BlogRepo.GetSendend())
                    {
                        Console.WriteLine(blog.GetInfoSended());
                    }
                }
                else if (command == "/approve-blog")
                {
                    Console.WriteLine("Please enter blog kod : ");
                    string blogKod = Console.ReadLine();
                    Blog blog = blogRepo.GetById(blogKod);
                    if (blog != null)
                    {
                        if (blog.BlogStatus == BlogStatus.Sended)
                        {
                            blog.BlogStatus = BlogStatus.Accepted;
                            Inbox inbox = new Inbox($"This code{blog.Id},admin{CurrentUser.Name}{CurrentUser.LastName} Aproved this blog", blog.FromUser);
                            inboxRepo.Add(inbox);
                        }
                    }
                    else
                    {
                        Console.WriteLine("blog is not found in system");
                    }

                }
                else if (command == "/reject-blog")
                {
                    Console.WriteLine("Please enter blog kod : ");
                    string blogKod = Console.ReadLine();
                    Blog blog = blogRepo.GetById(blogKod);
                    if (blog != null)
                    {
                        if (blog.BlogStatus == BlogStatus.Sended)
                        {
                            blog.BlogStatus = BlogStatus.Rejected;
                            Inbox inbox = new Inbox($"This code{blog.Id},admin{CurrentUser.Name}{CurrentUser.LastName} Rejected this blog", blog.FromUser);
                            inboxRepo.Add(inbox);
                        }
                    }
                    else
                    {
                        Console.WriteLine("blog is not found in system");
                    }
                }
                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
            }
        }
        public static void UserPanel(User user)
        {
            BlogRepo blogRepo = new BlogRepo();

            InboxRepo inboxRepo = new InboxRepo();

            Repo<Comment, int> CommentRepo = new Repo<Comment, int>();
            CurrentUser = user;

            Console.WriteLine($"Welcome to your account <FirstName : {user.Name}> <LastName : {user.LastName}> <Email : {user.Email}>!");
            Console.WriteLine("/inbox");
            Console.WriteLine("/add-comment");
            Console.WriteLine("/add-blog");
            Console.WriteLine("/delete");
            Console.WriteLine("/blogs");
            Console.WriteLine("/logout");
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "/inbox")
                {
                    int counter = 1;
                    foreach (Inbox inbox in inboxRepo.GetAll())
                    {
                        if (inbox.User == CurrentUser)
                        {
                            Console.WriteLine(counter + " " + inbox.Notification);
                            counter++;
                        }
                    }
                }
                else if (command == "/add-comment")
                {
                    Console.WriteLine("Please Eter id for comment : ");
                    string blogID = Console.ReadLine();
                    Blog findBlog = blogRepo.GetById(blogID);
                    if (findBlog != null)
                    {
                        Console.WriteLine($"Please enter to this blog : {findBlog.Title}");

                        Comment comment = new Comment(CurrentUser, Authenfication.GetThisComment(), findBlog);
                        CommentRepo.Add(comment);
                        Inbox inbox = new Inbox($"This code{findBlog.Id} {findBlog.FromUser.Name}{findBlog.FromUser.LastName} add comment ", findBlog.FromUser);
                        inboxRepo.Add(inbox);
                    }

                }
                else if (command == "/add-blog")
                {

                    Blog blog = new Blog(CurrentUser, Authenfication.GetNameBlog(), Authenfication.GetTextBlog(), BlogStatus.Sended);

                    blogRepo.Add(blog);
                    Console.WriteLine("Blog added");
                }
                else if (command == "/delete")
                {

                    foreach (Blog blog in BlogRepo.Get(CurrentUser.Id))
                    {
                        if (blog.FromUser == CurrentUser)
                        {
                            Console.WriteLine(blog.GetInfo());

                        }
                    }
                    Console.WriteLine("Please enter blog id : ");
                    string blogID = Console.ReadLine();
                    Blog findBlog = blogRepo.GetById(blogID);
                    List<Comment> comments = CommentRepo.GetAll(c => c.Blog == findBlog);
                    List<Inbox> inboxes = inboxRepo.GetAll(i => i.Notification.Contains(findBlog.Id));


                    if (findBlog != null && findBlog.FromUser == CurrentUser)
                    {
                        blogRepo.Delete(findBlog);
                        foreach (Comment comment in comments)
                        {
                            CommentRepo.Delete(comment);
                        }
                        foreach (Inbox inbox in inboxes)
                        {
                            inboxRepo.Delete(inbox);
                        }


                    }
                    else if (findBlog == null)
                    {
                        Console.WriteLine("This blog is not have ");
                    }
                    else if (findBlog.FromUser != CurrentUser)
                    {
                        Console.WriteLine("This is not yours blog ");
                    }
                }
                else if (command == "/blogs")
                {

                    foreach (Blog blog in BlogRepo.Get(CurrentUser.Id))
                    {
                        if (blog.FromUser == CurrentUser)
                        {
                            Console.WriteLine(blog.GetInfo());

                        }
                    }


                }
                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
            }
        }
    }
}
