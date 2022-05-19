using CrudWithConsoleApp.Db;
using System;
    class Program
{
    static void Main()
    {
        int id = 0;
        string Name;
        string ?Email;
        string ?PhoneType;
        string ?PhoneNumber;
        int Age;
        string ?Notes;
        Contact c;
        int selection;
        bool sel = true;


        Console.WriteLine("Hello Customer!");
        
       
        try
        {
            while (sel == true)
            {
                selection = Selection();
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Check out the full directory");
                        GetContact();
                        

                        break;

                    case 2:
                        Console.WriteLine("Enter the ContactName");
                        Name = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Enter the ContactEmail");
                        Email = Console.ReadLine();
                        Console.WriteLine("Enter the ContactPhoneType");
                        PhoneType = Console.ReadLine();
                        Console.WriteLine("Enter the ContactPhoneNumber");
                        PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Enter the ContactAge");
                        Age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ContactNotes");
                        Notes = Console.ReadLine();

                        c = new Contact()
                        {

                            ContactName = Name,
                            ContactEmail = Email,
                            ContactPhoneType = PhoneType,
                            ContactPhoneNumber = PhoneNumber,
                            ContactAge = Age,
                            ContactNotes = Notes,
                            ContactCreatedDate = DateTime.Now
                        };

                        AddContact(c);
                        Console.WriteLine("Contact has been inserted");
                        Console.WriteLine("Check out the full directory");
                        GetContact();
                       
                        break;


                    case 3:
                        Console.WriteLine("Enter the id you want to Update");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ContactName");
                        Name = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Enter the ContactEmail");
                        Email = Console.ReadLine();
                        Console.WriteLine("Enter the ContactPhoneType");
                        PhoneType = Console.ReadLine();
                        Console.WriteLine("Enter the ContactPhoneNumber");
                        PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Enter the ContactAge");
                        Age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ContactNotes");
                        Notes = Console.ReadLine();

                        c = new Contact()
                        {
                            ContactId = id,
                            ContactName = Name,
                            ContactEmail = Email,
                            ContactPhoneType = PhoneType,
                            ContactPhoneNumber = PhoneNumber,
                            ContactAge = Age,
                            ContactNotes = Notes,
                            ContactCreatedDate = DateTime.Now
                        };
                        UpdateContact( c);

                        Console.WriteLine("Contact has been Updated");
                        Console.WriteLine("Check out the full directory");
                        GetContact();
                        

                        break;


                    case 4:
                        Console.WriteLine("Enter the id you want to Delete");
                        id = Convert.ToInt32(Console.ReadLine());
                        DeleteContact(id);

                        Console.WriteLine("Contact has been Deleted");
                        Console.WriteLine("Check out the full directory");
                        GetContact();
                       

                        break;
                    case 5:
                        sel = false;
                        break;



                }
            }
        }
       catch (Exception )
        {
            Console.WriteLine("Invalid selection");
            Console.ReadLine();
        }

       // GetContact();

    
       // Console.WriteLine("Enter the id you want to Delete");
       // id = Convert.ToInt32(Console.ReadLine());
       // DeleteContact(id);
       // GetContact();
       // //AddContact();

       //// Console.WriteLine("Inserting data to DB");
       //// Console.ReadLine();
       //// Console.WriteLine("Enter the id you want to update");
       ////id = Convert.ToInt32(Console.ReadLine());
       //// UpdateContact(id);
    }

    static void AddContact(Contact contact)
    {
        Contact c = new Contact();
        using (var contactscontext = new ContactsContext())
        {
            c = contact;
            contactscontext.Add(c);
            contactscontext.SaveChanges();
        }
    }

    static void UpdateContact( Contact contact)
    {
        Contact c = new Contact();
        using (var contactscontext = new ContactsContext())
        {
            c = contact;
            contactscontext.Update(c);
            contactscontext.SaveChanges();
        }
    }

    static void GetContact()
    {
        using (var contactscontext = new ContactsContext())
        {
            foreach (var i in contactscontext.Contacts.ToList())
            { Console.WriteLine($"ContactId = {i.ContactId} , ContactName = {i.ContactName} , ContactEmail = {i.ContactEmail}, ContactPhoneType = { i.ContactPhoneType}, ContactPhoneNumber = {i.ContactPhoneNumber} , ContactAge = {i.ContactAge} ,  ContactNotes = {i.ContactNotes} , ContactCreatedDate = {i.ContactCreatedDate}" ); 
           }
            
        }
    }

    static void DeleteContact(int id)
    {
        using (var contactscontext = new ContactsContext())
        {
            Contact c = new Contact()
            {
                ContactId = id,
               
            };
            contactscontext.Remove(c);
            contactscontext.SaveChanges();
        }
    }

    static int Selection()
    {
        int selection;
        Console.WriteLine("Enter 1 to check all the contacts in the directory");
        Console.WriteLine("Enter 2 to Add a contact in the directory");
        Console.WriteLine("Enter 3 to update a contact in the directory");
        Console.WriteLine("Enter 4 to delete a contact in the directory");
        Console.WriteLine("Enter 5 to quite");
        selection = Convert.ToInt32(Console.ReadLine());
        return selection;
    }
}