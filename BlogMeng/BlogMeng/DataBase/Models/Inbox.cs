using ConsoleApp1.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Models
{
    public class Inbox : Entity<int>
    {
        public string Notification { get; set; }
        public User User { get; set; }

        public Inbox(string notification, User user, int? id = null)
        {
            Notification = notification;
            User = user;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserRepo.IDCounter;
            }


        }
    }
}
