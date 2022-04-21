using System;

class Program20
{
    static void Main()
    {
        int sum = 0;

        while (sum<100)
        {
            Console.Write("Enter a number:");
            string input = Console.ReadLine();

            int number = int.Parse(input);

            sum = sum + number;

            Console.WriteLine("Current sum is {0}", sum);
        }
        Console.WriteLine("total sum is {0}", sum);
        Console.ReadLine();
    }
}