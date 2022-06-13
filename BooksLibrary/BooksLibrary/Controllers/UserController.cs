using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BooksLibrary.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BooksLibrary.Controllers
{
    [Authorize(Roles = "validUser")]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;


        public UserController(IConfiguration configuration)
        {
            this._configuration = configuration;

        }
        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult AddToCart(int id, int qty)
        {
            ShoppingCart cart = new ShoppingCart();
            List<ShoppingCart> carts = new List<ShoppingCart>();
            BookViewModel bookViewModel = new BookViewModel();
           

            bookViewModel.qty = qty;


            if (bookViewModel.qty == 0)
            {

                bookViewModel = FetchBookByID(id);
                

            }
            else
            {
                bookViewModel = FetchBookByID(id);
                bookViewModel.qty = qty;
                bookViewModel.Price = bookViewModel.qty * bookViewModel.Price;
                cart=Add(bookViewModel);
                carts = GetCarts();


            return View("Checkout",carts);
            }

            return View(bookViewModel);
        }

        
       public IActionResult Checkout( int bookid) 
        {
            
            List<ShoppingCart> carts = new List<ShoppingCart>();
            carts = GetCarts();
            if (bookid == 0 && carts.Count != 0)
            {
                ViewBag.result = "Order Placed successfully!";
                RemoveCart();
            }

            else if (bookid != 0 && carts.Count != 0)
            {
                RemoveCartByBookId (bookid);
                carts = GetCarts();
                ViewBag.result = "Item has been successfully removed";
            }

            else if (bookid == 0 && carts.Count==0)
            {
                ViewBag.result = "There is currently no item's in the cart!";
            }

           
            return View(carts); 
        }


            public BookViewModel FetchBookByID(int? id)
        {
            BookViewModel bookViewModel = new BookViewModel();

            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("BookViewByID", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("BookID", id);
                sqlDa.Fill(dataTable);
                if (dataTable.Rows.Count == 1)
                {
                    bookViewModel.BookID = Convert.ToInt32(dataTable.Rows[0]["BookID"].ToString());
                    bookViewModel.Title = dataTable.Rows[0]["Title"].ToString();
                    bookViewModel.Author = dataTable.Rows[0]["Author"].ToString();
                    bookViewModel.Price = Convert.ToInt32(dataTable.Rows[0]["Price"].ToString());
                    bookViewModel.Category = dataTable.Rows[0]["Category"].ToString();
                }
                return bookViewModel;

            }

        }


        public ShoppingCart Add(BookViewModel bookViewModel)
        {

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("AddOrUpdateShoppingCart", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("BookID", bookViewModel.BookID);
                sqlCmd.Parameters.AddWithValue("Quantity", bookViewModel.qty);
                sqlCmd.Parameters.AddWithValue("UserName", HttpContext.Session.GetString("User"));
               
                sqlCmd.ExecuteNonQuery();


            }

            return new ShoppingCart
            {
                BookId = bookViewModel.BookID,
                qty = bookViewModel.qty,
                Author = bookViewModel.Author,
                Title = bookViewModel.Title,
                Price = bookViewModel.Price,
                UserName = HttpContext.Session.GetString("User")
            };
        }

        public void RemoveCart()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("RemoveCart", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("UserName", HttpContext.Session.GetString("User"));

                sqlCmd.ExecuteNonQuery();
            }
        }

        public void RemoveCartByBookId(int bookid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("RemoveCartByBookId", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("BookId", bookid);
                sqlCmd.Parameters.AddWithValue("UserName", HttpContext.Session.GetString("User"));

                sqlCmd.ExecuteNonQuery();
            }
        }

        public List<ShoppingCart> GetCarts()
        {
            List<ShoppingCart> carts = new List<ShoppingCart>();
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetShoppingCart", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("UserName", HttpContext.Session.GetString("User"));
                sqlDa.Fill(dataTable);

            }


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {


                carts.Add(new ShoppingCart
                {
                    BookId = Convert.ToInt32(dataTable.Rows[i]["BookId"].ToString()),
                    UserName= dataTable.Rows[i]["BookId"].ToString(),
                    qty = Convert.ToInt32(dataTable.Rows[i]["Quantity"].ToString()),
                    Title = dataTable.Rows[i]["Title"].ToString(),
                    Author = dataTable.Rows[i]["Author"].ToString(),    
                    Price= (Convert.ToInt32(dataTable.Rows[i]["Price"].ToString())) * (Convert.ToInt32(dataTable.Rows[i]["Quantity"].ToString()))
                });
            }

            return carts;
        }



       
    }
}
