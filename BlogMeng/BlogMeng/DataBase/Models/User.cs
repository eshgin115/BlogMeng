using ConsoleApp1.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Models
{
    public class User : Entity<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime RigisterTime { get; set; } = DateTime.Now;
        public User(string name, string lastName, string email, string password, int? id = null)
        {
            Name = name;
            LastName = lastName;

            Email = email;
            Password = password;
            if (id != null)
            {
                Id = id.Value;
            }
            else if (id == null)
            {


            }
        }
        public virtual string GetInfo()
        {
            return Name + " " + LastName + " " + Email + " " + Password;
        }
    }
}
