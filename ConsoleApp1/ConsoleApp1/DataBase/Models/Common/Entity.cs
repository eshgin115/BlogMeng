using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Models.Common
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }

    }
}
