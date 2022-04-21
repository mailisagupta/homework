using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.week3
{
    class Class3string
    {
        static void Main()
        {
            Console.Write("Enter a person's full name:");
            string str = Console.ReadLine();

            if (str.EndsWith("Smith"))
              {
                Console.WriteLine("Smith is found");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Smith is not found");
                
            }

            Console.ReadLine();
        }
    }
}
