﻿using System;

class swap1
{
    static void Main()
    {
        var x = 11;
        var y = 22;

        Swap(ref x, ref y);

        Console.WriteLine("X={0} should be 22", x);
        Console.WriteLine("Y={0} should be 11", y);
        Console.ReadLine();
    }

    // Write the Swap method so that
    // the two values passed in are swapped.
    static void Swap(ref int X, ref int Y )
    {
        int temp= X;
        X = Y;
        Y = temp;
    }
}