﻿using System;

class Labwork
{
    static void Main()
    {
        while (true)
        {
            int[] numbers = new int[] { 10, 15, 20, 25, 30, 35 };

            Console.Write("Enter a number:");
            string str = Console.ReadLine();

            // TODO: convert input string into a number
            int number = int.Parse(str);
            bool found = false;

            // TODO: set a boolean flag named "found"


            // use for to look for the number
            for (int i = 0; i< numbers.Length; i ++)
            {
                // TODO: if number is found set found flag to true and exit the loop
                if (number == numbers[i])
                {
                    found = true;
                    break;
                }
                

            }

            if (found) // if true, i.e. found the number, say Found the Number
            {
                Console.WriteLine("Found the number!");
            }
            else // if not true, did not find it, say Did not Find the Number
            {
                Console.WriteLine("Sorry, did not find the number");
            }

            Console.ReadLine(); // Pause to see the results
        }
    }
}