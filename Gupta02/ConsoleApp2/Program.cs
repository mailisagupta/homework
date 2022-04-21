using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;

/// <summary>
/// Gupta, Mailisa , mailisa
/// </summary>
namespace ConsoleApp2
{
    class Program
    {
        public static void Main()
        {
            DoubleLinkedList dll = new DoubleLinkedList();
            dll.Add(10);
            dll.Add(20);
            dll.Add(30);
            dll.Add(40);
            dll.Add(50);
            dll.Print();
            
            dll.Remove(50);
            dll.Print();

            dll.InReverse();
            dll.Print();

            Console.ReadLine();

/////////////////////////////////////////////////////////////////////////////////////////////////

            DoubleLinkedListGeneric<string> dllg = new DoubleLinkedListGeneric<string>();
            string[] sentence = "My name is Mailisa Gupta and i want to learn good programmimg skills".Split(' '); 
            foreach (string i in sentence)
            {
                dllg.Add(i);
            }
            
            dllg.PrintGeneric();

            dllg.Remove("good");
            dllg.PrintGeneric();

            ///dllg.GetEnumeratorReverse();
            foreach(string a in dllg)
            {
                a.PrintGeneric();
            }

            IEnumerable<string> result = dllg.Reverse(); 
            foreach (var item in result)
            {
                ///Console.WriteLine(item);
                item.PrintGeneric();
            }
            Console.ReadLine();



            dllg.PrintGeneric();
            dllg.InReverse(); ///// it will reverse the list permanently.
            dllg.PrintGeneric();

          

            

            Console.ReadLine();
//////////////////////////////////////////////////////////////////////////////////////////

           
        }
    }
}
