using Microsoft.AspNetCore.Mvc;
using BooksLibrary.Data;
using BooksLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BooksLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IConfiguration _configuration;

        public BookController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Book
        public IActionResult Index()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("BookViewAll", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dataTable);

            }
            return View(dataTable);
        }

       
        // GET: Book/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
           BookViewModel bookViewModel = new BookViewModel();  
            if (id > 0)
            {
                bookViewModel = FetchBookByID(id);
            }
            return View(bookViewModel);
        }

        // POST: Book/AddOrEdit/
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("BookID,Title,Author,Price")] BookViewModel bookViewModel)
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
                    sqlCmd.ExecuteNonQuery();


                }
                return RedirectToAction(nameof(Index));
            }
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
            return RedirectToAction(nameof(Index));
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
                }
                return bookViewModel;

            }

        }

       
    }
}
