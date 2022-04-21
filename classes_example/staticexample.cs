using System;

struct Contact1
{
    public static int ContactId;
    public String Name;
    public String PhoneNumber;

    public Contact1(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        ContactId = nextContactID++;
    }

    // TODO: Create static nextContactId

    private static int nextContactID = 100;

    public static int CurrentNextContactId
    {
        get { return nextContactID; }
        
    }
}

class staticexample
{
    static void Main()
    {
        Console.WriteLine("CurrentNextContactId = {0} should be 100", Contact1.CurrentNextContactId);

        var contact = new Contact1("mike", "111-222-3333");

        // TODO: Why does is not compile? What does the compiler say?
        Console.WriteLine("CurrentNextContactId = {0} should be 101", Contact1.CurrentNextContactId);

        var contact2 = new Contact1("steve", "222-333-4444");

        // TODO: Why does is not compile? What does the compiler say?
        Console.WriteLine("CurrentNextContactId = {0} should be 102", Contact1.CurrentNextContactId);

        Console.ReadLine();
    }
}