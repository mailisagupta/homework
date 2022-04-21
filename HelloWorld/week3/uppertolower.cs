///Write a program to convert all a given uppercase string into a lowercase string.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.week3
{
    class uppertolower
    {
        static void Main() 
        {
            Console.WriteLine("enter the string in upper case");
            string x = Console.ReadLine();
            x = x.ToLower();
            Console.WriteLine("string in lower case is :{0}",x);
            Console.ReadLine();
        }
    }
}
