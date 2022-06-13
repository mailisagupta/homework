using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Models
{
    public class BookType
    {
        [Key]
        public int BookTypeID { get; set; }
        
        public string BookTypeName { get; set; }
        
    }
}
