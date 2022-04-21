// Create an array of numbers and find the max and min values of your array

using System;

class Program30
{
    static void Main()
    {

        // start with the given array
        int[] numbers = new int[] { 0, 2, 5, 100, -1, 4, 8, -5 ,200, -1000 };
        int min = 0;
        int max = 0;


        // define the max and min

        foreach (int x in numbers)
        {
            if (x <= min )
            {
                min = x;
            }
            if (x>=max)
               {
                max = x;
            }
        }

        Console.WriteLine("The Minimum value is {0}", min);
        Console.WriteLine("The Maximum value is {0}", max);

        Console.ReadLine();
    }
}