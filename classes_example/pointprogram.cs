using System;
class pointprogramm
{
    static void Main()
    {
        // TODO: Define an overloaded constructor
        // that takes two doubles and casts them to integers
        var myPoint = new Point(10.0, 20.0);

        myPoint.Add(11, 22);

        Console.WriteLine("X={0} Y={1}", myPoint.GetX(), myPoint.GetY());

        var secondPoint = new Point(1000, 2000);

        // TODO: Add overloaded Add method that takes a Point
        myPoint.Add(secondPoint);

        Console.WriteLine("X={0} Y={1}", myPoint.GetX(), myPoint.GetY());

        Console.ReadLine();
    }
}