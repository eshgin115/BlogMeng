using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AppLogic.Validations
{
    public class CommoonValidations
    {

        public static bool Count(string text, Predicate<int> countLogic)
        {
            if (countLogic(text.Length))
            {
                return true;
            }
            Console.WriteLine("Lentgh is not correct");
            return false;
        }

    }
}
