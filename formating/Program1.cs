using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formating
{
    class Program1

    {
        static void Main()
        {
            Console.WriteLine("ID    Name       Price");
            Console.WriteLine("----- ---------- --------");
            Console.WriteLine("{0,5} {1,-10} {2,8:C}", 101, "apple", .25);
            Console.WriteLine("{0,5} {1,-10} {2,8:C}", 102, "pear", .26);
            Console.WriteLine("{0,5} {1,-10} {2,8:C}", 4, "pineapple", 1.20);
            Console.ReadLine();

        }
    }
}
