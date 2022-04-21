using System;
using ClassLibrary1;
/// <summary>
/// Gupta, Mailisa , mailisa
/// </summary>
namespace ConsoleApp2
{
    public static class ExtensionPrint 
    {
        public static void Print(this DoubleLinkedList d)
        {
            Console.WriteLine(d);
        }

        public static void PrintGeneric<T>(this T dg)
        {
            Console.WriteLine(dg);
        }

    }
}
