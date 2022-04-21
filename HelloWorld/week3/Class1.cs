using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.week3
{
    class Ascii
    {
        static void Main()
        {
            Console.Write("Enter a character:");
            string x = Console.ReadLine();
            // Let the user enter a string and press enter.
            // code here = Console.ReadLine();

            // Grab the first character of the string (str[0])
            char m = x[0];

            // Convert the character to an integer to get the ascii value
            int t = (int)m;

            Console.WriteLine("{0}", t);  // show the ascii value
            Console.ReadLine();
        }
    }
}
