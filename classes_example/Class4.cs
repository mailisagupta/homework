using System;
using System.Collections.Generic;

struct Contact
{
    public String Name;
    public String PhoneNumber;
}

class listexample
{
    static void Main()
    {
        // TODO: Create a list of Contact
        var contacts=new List<Contact>();
        var c = new Contact { Name = "mailisa", PhoneNumber = "2345" };
        var d = new Contact { Name = "ravi", PhoneNumber = "1234" };
        // TODO: Add contacts to the list
        contacts.Add(c);
        contacts.Add(d);

        // TODO: Display the Name and PhoneNumber of all the contacts
        foreach (var t in contacts )
        {
            Console.WriteLine("{0} {1} ", t.Name, t.PhoneNumber);
        }

        Console.ReadLine();
    }
}