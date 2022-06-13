namespace BooksLibrary.Models
{
    public class ShoppingCart
    {
       
            public string Title { get; set; }
            public int BookId { get; set; }
            public int qty { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public string UserName { get; set; }


        public string Message { get; set; }


    }
}
