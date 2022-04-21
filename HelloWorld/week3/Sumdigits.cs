
///Write a program that calculates the sum of the digits of an integer. Do not use the input string, convert the user inputted string to an integer and process that integer. For example, the sum of the digits of the integer number 2155 is 2 + 1 + 5 + 5 or 13. The program should accept any arbitrary integer typed in by the user and output the following: (Hint: Assume the number is never greater than 9999.)
////2155 = 2 + 1 + 5 + 5 = 13
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.week3
{
    class Sumdigits
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("enter the number");
                string x = Console.ReadLine();

                int number = int.Parse(x);
                int sum = 0;

                while (number != 0)
                {
                    sum = sum + (number % 10);
                    number = number / 10;
                }

                Console.WriteLine("sum of digits= {0}", sum);
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("invalid entry");
                Console.ReadLine();
            }
        }
    }
}
