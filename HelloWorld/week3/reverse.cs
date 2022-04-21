// Write a program to reverse a given string (apple will be reversed to elppa) or to reverse a given number (1234 will become 4321).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.week3
{
    class reverse
    {
        static void Main() 
        {
            while (true)
            {
                Console.WriteLine("enter the string you want to reverse");
                string x = Console.ReadLine();
                int len = x.Length;
                string y = "";
                for (int i = (len - 1); i >= 0; i--)
                {
                    y = y + x[i];

                }
                Console.WriteLine("the reversed value is: {0}", y);
                Console.ReadLine();
            }
        }
    }
}
