using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formating
{
    class Class2
    {
        static void Main()
        {
            string input;
            int intval;
            double dbval;
            ///parse convert string to numeric
            ///tostring convert numeric to string
            input = "45";
            intval = int.Parse(input);
            Console.WriteLine(intval);

            input = "1234.567";
            dbval = double.Parse(input);
            Console.WriteLine(dbval);
            string output = intval.ToString();
            Console.WriteLine(output);
            Console.ReadLine();

            // Display "Enter a price:" using Console.Write
            Console.WriteLine("Enter a price:");
            // Define a string named "input"
            string input1;
            // Assign "input" to Console.ReadLine() to allow the user to enter a price
            input1 = Console.ReadLine();
            // Define a double named price
            double price;

            // Convert the "input" into a double using Parse()
            price = double.Parse(input1);
            // Display the price as currency ( {0:C} )
            Console.WriteLine("The price is {0:C}", price);
            Console.ReadLine();


        }
    }
}
