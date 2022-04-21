using System;

class Program10
{
    static void Main()
    {
        int index = 1;
        int sum = 0;

        while (sum < 100)
        {
            sum = sum + index;

            ///Console.WriteLine("Sum of 1 through {0} is {1}", index, sum);
            index++;
        }

        Console.WriteLine("Sum of 1 through {0} is {1}", index, sum); 
        Console.ReadLine();
    }
}