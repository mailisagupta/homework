﻿// Write a program that calculates the average of numbers given by the user.

using System;

class Average
{
    static void Main()
    {
        // define a float for sum
        // define a float for average
        float sum = 0;
        float average = 0;

        // sequentially add the numbers up from 0 to 10

        for (int x = 0;x<10 ; x++ ) 
        {
            //ask the user to enter a number
            Console.WriteLine("enter the number");
            sum= sum+ float.Parse(Console.ReadLine());
            //add the given number to the previous

        }

        // finding the average
        average = sum / 10;
        Console.WriteLine("The average of the given numbers is {0}", average);
        Console.ReadLine();
    }

}