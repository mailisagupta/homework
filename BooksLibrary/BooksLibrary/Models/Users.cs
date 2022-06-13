using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Models
{
    public class Users
    {
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        public string UserLoginErrorMessage { get; set; }
        [Required]
        public string UserFullName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
