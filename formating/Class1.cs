﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formating
{
    class Class1
    {
        static void Main()
        {
            while (true) ////allow keep trying
            {
                // Ask for an input 
                Console.Write("Please enter an integer value for x: ");

                // Read the input and save it into a String Type
                string input = Console.ReadLine();

                // Convert the String Type into an Integer Type
                int x = int.Parse(input);  // convert a string into an integer type

                // Calculate the Polynomial (3x^3-5x^2+6) and save it into an Integer Type
                int result = (3 * x * x * x) - (5 * x * x) + 6;

                // Show the result on the Console (on the screen)
                Console.WriteLine("The calculated value for 3x^3-5x^2+6 is {0}", result);

                // Hold the Console so we can see the result
                Console.ReadLine();
            }
        }
    }
}
