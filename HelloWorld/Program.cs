using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");

        Console.ReadLine();
        int x = 5;
        x = x + 1;
        x++;
        Console.WriteLine("x={0}", x);
        int y;
        y = 0;
        y++;
        Console.WriteLine("y={0}", y);
        Console.ReadLine();

        Console.WriteLine("ID    Name       Price");
        Console.WriteLine("----- ---------- --------");
        Console.WriteLine("{0,5} {1,-10} {2,8:C}", 101, "apple", .25);
        Console.WriteLine("{0,5} {1,-10} {2,8:C}", 102, "pear", .26);
        Console.WriteLine("{0,5} {1,-10} {2,8:C}", 4, "pineapple", 1.20);
        Console.ReadLine();

    }
}