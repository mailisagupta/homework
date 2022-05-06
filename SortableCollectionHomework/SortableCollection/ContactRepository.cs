using SortableCollection.Models;

namespace SortableCollection
{
    public interface IContactRepository
    {
        IEnumerable<Contact> contact { get; }
    }

    public class ContactRepository : IContactRepository
    {
        public IEnumerable<Contact> contact 
        {
            get
            {
                var contacts = new[]
     {
        new Contact{Id = 1, Name="dave", City="Seattle", State="WA", Phone="123"},
        new Contact{Id = 2, Name="mike", City="Spokane", State="WA", Phone="234"},
        new Contact{Id = 3, Name="lisa", City="San Jose", State="CA", Phone="345"},
        new Contact{Id = 4, Name="cathy", City="Dallas", State="TX", Phone="456"},
    };
                return contacts;
            }
        }
    }
}
