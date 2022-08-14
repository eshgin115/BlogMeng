using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Models
{
    public class Admin : User
    {
        public Admin(string name, string lastName, string email, string password, int? id = null)
            : base(name, lastName, email, password, id)
        {
        }

        public override string GetInfo()
        {
            return Name + " " + LastName + " " + Email + " " + RigisterTime;
        }
    }
}
