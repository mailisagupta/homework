﻿using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Models
{
    public class BookViewModel
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Range(1,int.MaxValue, ErrorMessage ="Should be equal to or greater than 1")]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }

        public int qty { get; set; }
        public List<BookType> Categories { get; set; }

    }
}
