using Microsoft.AspNetCore.Mvc;
using BooksLibrary.Data;
using BooksLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksLibrary.Controllers
{ [Authorize (AuthenticationSchemes = "MyCookie")]
    public class BookController : Controller
    {
        private readonly IConfiguration _configuration;
        

        public BookController(IConfiguration configuration)
        {
            this._configuration = configuration;
         
        }
        
        // GET: Book
        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
           List<BookViewModel> books = new List<BookViewModel>();
            ///Admin admin = new Admin();
            sortOrder = string.IsNullOrEmpty(sortOrder) ? "Title" : sortOrder;
            DataTable dataTable = new DataTable();
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("BookViewAll", sqlConnection);
                    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDa.Fill(dataTable);

                }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {


                books.Add(new BookViewModel
                {   BookID = Convert.ToInt32(dataTable.Rows[i]["BookID"].ToString()),
                    Title = dataTable.Rows[i]["Title"].ToString(),
                    Author = dataTable.Rows[i]["Author"].ToString(),
                    Price =Convert.ToInt32(dataTable.Rows[i]["Price"].ToString())
                });
            }
            var _books = books.AsQueryable();
            switch (sortOrder)
            {
                case "Title":
                    _books = _books.OrderByDescending(b => b.Title);
                    break;
                case "Author":
                    _books = _books.OrderByDescending(b => b.Author);
                    break;
                case "Price":
                    _books = _books.OrderByDescending(b => b.Price);
                    break;
                   
            }

                return View(_books);


           
        }

       
        // GET: Book/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
           BookViewModel bookViewModel = new BookViewModel();  
            List<BookType> bookT = new List<BookType>();
            
            //var categoryList = bookT.ToList();
            //SelectList l1 = new SelectList(categoryList, "BookTypeID", "BookTypeName");
            //ViewBag.Category = l1;
            

            if (id > 0)
            {
                
                bookViewModel = FetchBookByID(id);
                bookT = GetBooksType();
                bookViewModel.Categories = bookT;
            }
            else
            {
                bookT = GetBooksType();
                bookViewModel.Categories = bookT;
            }
            return View(bookViewModel);
        }

        // POST: Book/AddOrEdit/
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("BookID,Title,Author,Price,Category")] BookViewModel bookViewModel)
        { 
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("BookAddOrEdit", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("BookID", bookViewModel.BookID);
                    sqlCmd.Parameters.AddWithValue("Title", bookViewModel.Title);
                    sqlCmd.Parameters.AddWithValue("Author", bookViewModel.Author);
                    sqlCmd.Parameters.AddWithValue("Price", bookViewModel.Price);
                    sqlCmd.Parameters.AddWithValue("Category",bookViewModel.Category);
                    sqlCmd.ExecuteNonQuery();


                }
                return RedirectToAction("BooksByType","Home");
            }
            List<BookType> bookT = new List<BookType>();
            bookT = GetBooksType();
            bookViewModel.Categories = bookT;
            return View(bookViewModel);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {

            BookViewModel bookViewModel = FetchBookByID(id);
            return View(bookViewModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("BookDeleteByID", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("BookID", id);
                
                sqlCmd.ExecuteNonQuery();


            }
            return RedirectToAction("BooksByType", "Home");
        }

        public BookViewModel FetchBookByID (int? id) 
        {
            BookViewModel bookViewModel = new BookViewModel();

            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("BookViewByID", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("BookID",id);
                sqlDa.Fill(dataTable);
                if (dataTable.Rows.Count == 1)
                {
                    bookViewModel.BookID=Convert.ToInt32(dataTable.Rows[0]["BookID"].ToString());
                    bookViewModel.Title = dataTable.Rows[0]["Title"].ToString();
                    bookViewModel.Author = dataTable.Rows[0]["Author"].ToString();
                    bookViewModel.Price = Convert.ToInt32(dataTable.Rows[0]["Price"].ToString());
                    bookViewModel.Category = dataTable.Rows[0]["Category"].ToString();
                }
                return bookViewModel;

            }

        }

        public List<BookType> GetBooksType()
        {
            List<BookType> bookType = new List<BookType>();
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetBookTypeForAddOrEdit", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dataTable);

            }
            for (int i = 0; i< dataTable.Rows.Count; i++)
            {
               

                bookType.Add(new BookType
                {
                    BookTypeID = Convert.ToInt32(dataTable.Rows[i]["BooksTypeID"].ToString()),
                    BookTypeName= dataTable.Rows[i]["BooksTypeName"].ToString()
            });
            }
            return bookType;
        }

       
    }
}
