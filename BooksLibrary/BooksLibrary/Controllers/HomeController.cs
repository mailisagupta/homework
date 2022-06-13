using BooksLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BooksLibrary.Controllers
{  [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this._configuration = configuration;
        }

        public IActionResult Index(string user)
        {
            if (user == "admin")
            {
                return RedirectToAction("Login", "Authentication");
            }///return View("~/Views/Authentication/Login.cshtml");  }

            if (user == "ruser") { return RedirectToAction("LoginUser", "Authentication"); }
            return View();
        }
        //[HttpPost]
        //public IActionResult Admin([Bind("AdminUserName,AdminPassword")] Admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
        //        {
        //            sqlConnection.Open();
        //            SqlCommand sqlCmd = new SqlCommand("ValidateAdmin", sqlConnection);
        //            sqlCmd.CommandType = CommandType.StoredProcedure;
        //            sqlCmd.Parameters.AddWithValue("AdminUserName", admin.AdminUserName);
        //            sqlCmd.Parameters.AddWithValue("AdminPassword", admin.AdminPassword);
        //            sqlCmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
        //            sqlCmd.ExecuteNonQuery();
        //            ViewBag.CountLog = sqlCmd.Parameters["@Count"].Value.ToString();

        //        }
  

        //    }

        //    if (ViewBag.CountLog != "1")
        //    {
        //        admin.LoginErrorMessage = "Admin id or Password is wrong.!";
        //    }
        //    else
        //    {
        //        HttpContext.Session.SetString("UserName",admin.AdminUserName);
        //        ///admin.IsAuth = true;
        //        return RedirectToAction("Index", "Book", admin);
        //    }

        //    return View(admin);
        //}

        public IActionResult Browse()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GetBookType", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dataTable);

            }
            return View(dataTable);
          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BooksByType(int ? id, string sortOrder , string SearchString, string CurrentFilter)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            ///Admin admin = new Admin();
            //sortOrder = string.IsNullOrEmpty(sortOrder) ? "Title" : "";
            ///BookViewModel bookViewModel = new BookViewModel(); 

            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "Title_desc" : "";
            ViewBag.AuthorSortParm = sortOrder == "Author" ? "Author_desc" : "Author";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";

            if (string.IsNullOrEmpty(SearchString) == true)
            {
                SearchString = CurrentFilter;
            }
            

            ViewBag.CurrentFilter = SearchString;

            DataTable dataTable = new DataTable();
            var _books = books.AsQueryable();
            ///if (id ==1 && string.IsNullOrEmpty(SearchString) == true)
                if (id == 1 || id == null)
                    {
                 if (string.IsNullOrEmpty(SearchString) == true) 
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                    {
                        sqlConnection.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("BookViewAll", sqlConnection);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;

                        sqlDa.Fill(dataTable);

                    }
                }
                 else
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                    {
                        sqlConnection.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("SearchBook", sqlConnection);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("SearchString", SearchString);
                        sqlDa.Fill(dataTable);

                    }
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {


                    books.Add(new BookViewModel
                    {
                        BookID = Convert.ToInt32(dataTable.Rows[i]["BookID"].ToString()),
                        Title = dataTable.Rows[i]["Title"].ToString(),
                        Author = dataTable.Rows[i]["Author"].ToString(),
                        Price = Convert.ToInt32(dataTable.Rows[i]["Price"].ToString())
                    });
                }
               
                switch (sortOrder)
                {
                    case "Title_desc":
                        _books = _books.OrderByDescending(b => b.Title);
                        break;
                    case "Author":
                        _books = _books.OrderBy(b => b.Author);
                        break;
                    case "Author_desc":
                        _books = _books.OrderByDescending(b => b.Author);
                        break;
                    case "Price_desc":
                        _books = _books.OrderByDescending(b => b.Price);
                        break;
                    case "Price":
                        _books = _books.OrderBy(b => b.Price);
                        break;
                    default:
                        _books = _books.OrderBy(b => b.Title);
                        break;


                }
            }

              //if (id != 1 && string.IsNullOrEmpty(SearchString) == true)
                else 
                {
                if (string.IsNullOrEmpty(SearchString) == true)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                    {
                        sqlConnection.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("GetBookByType", sqlConnection);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("BooksTypeid", id);
                        sqlDa.Fill(dataTable);

                    }
                }
                else
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                    {
                        sqlConnection.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("SearchBook", sqlConnection);
                        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDa.SelectCommand.Parameters.AddWithValue("SearchString", SearchString);
                        sqlDa.Fill(dataTable);

                    }
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {


                    books.Add(new BookViewModel
                    {
                        BookID = Convert.ToInt32(dataTable.Rows[i]["BookID"].ToString()),
                        Title = dataTable.Rows[i]["Title"].ToString(),
                        Author = dataTable.Rows[i]["Author"].ToString(),
                        Price = Convert.ToInt32(dataTable.Rows[i]["Price"].ToString())
                    });
                }
                
                switch (sortOrder)
                {
                    case "Title_desc":
                        _books = _books.OrderByDescending(b => b.Title);
                        break;
                    case "Author":
                        _books = _books.OrderBy(b => b.Author);
                        break;
                    case "Author_desc":
                        _books = _books.OrderByDescending(b => b.Author);
                        break;
                    case "Price_desc":
                        _books = _books.OrderByDescending(b => b.Price);
                        break;
                    case "Price":
                        _books = _books.OrderBy(b => b.Price);
                        break;
                    default:
                        _books = _books.OrderBy(b => b.Title);
                        break;

                }

               
            }
           

           
            return View(_books);
        }


    

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}