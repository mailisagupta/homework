using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Data
{
    public class BooksLibraryContext : DbContext
    {
        public BooksLibraryContext (DbContextOptions<BooksLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<BooksLibrary.Models.BookViewModel> BookViewModel { get; set; }
        public DbSet<BooksLibrary.Models.BookType> BookType { get; set; }

        public DbSet<BooksLibrary.Models.Admin> Admin { get; set; }

        public DbSet<BooksLibrary.Models.Admin> Users { get; set; }

    }
}
