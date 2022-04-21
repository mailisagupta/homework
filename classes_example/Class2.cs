using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_example
{
    class Class2
    {
        static void Main()
        {
            Contact contact = new Contact();

            contact.FirstName = "FirstName";
            contact.LastName = "LastName";
            contact.Age = 23;

            // GetFullName() returns "FirstName LastName"
            Console.WriteLine("Name: {0} Age: {1}", contact.GetFullName(), contact.Age);
            Console.ReadLine();
        }
    }
}
