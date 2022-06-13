using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        [Required]
        public string AdminUserName { get; set; }
        [Required]
        public string AdminPassword { get; set; }

        public string LoginErrorMessage { get; set; }

        public bool IsAuth { get; set; } = false;



    }
}
