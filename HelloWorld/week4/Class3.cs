using System;

class Program21
{
    static void Main()
    {
        // This called boxing
        object box = 15;
        Console.WriteLine("The value inside the box is {0}", box);

        // Convert the object box to a string
        Console.WriteLine("The ToString of the box is {0}", box.ToString());

        // This is called unboxing - converting an object to an integer
        int number = (int)box;
        Console.WriteLine("Number is {0}", number);

        Console.ReadLine();
    }
}