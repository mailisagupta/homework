using BooksLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Claims;

namespace BooksLibrary.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public AuthenticationController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this._configuration = configuration;
        }


        [HttpGet]
        public IActionResult LogOut()
        {
            // Get rid of the authentication cookie
            HttpContext.SignOutAsync(
    "MyCookie");

            // Go to home page
            //return Redirect("~/");
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Admin admin, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                if (ValidateAdmin(admin)=="1") 
                {
                    var claims = new List<Claim>
                    {
                        new Claim("user", admin.AdminUserName),
                        new Claim("role","member"),
                      
                    };

                    //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var principal = new ClaimsPrincipal(identity);

                    //var props = new AuthenticationProperties();

                    //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,props).Wait();
                    HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "MyCookie", "user", "role")));


                    ///admin.LoginErrorMessage = "You are successfully logged in";
                    
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }


                }
                else
                {
                    admin.LoginErrorMessage = "id or Password is wrong.!";
                }
            }
            return View(admin);
        }

        public string ValidateAdmin(Admin admin)
        {
            string i = "0";
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("ValidateAdmin", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("AdminUserName", admin.AdminUserName);
                    sqlCmd.Parameters.AddWithValue("AdminPassword", admin.AdminPassword);
                    sqlCmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCmd.ExecuteNonQuery();
                    i = sqlCmd.Parameters["@Count"].Value.ToString();

                }
            }
            return i;
        }

        public string ValidateUsers(Users user)
        {
            string i = "0";
            if (user.UserName is not null && user.UserPassword is not null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("ValidateUsers", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("UserName", user.UserName);
                    sqlCmd.Parameters.AddWithValue("UserPassword", user.UserPassword);
                    sqlCmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCmd.ExecuteNonQuery();
                    i = sqlCmd.Parameters["@Count"].Value.ToString();

                }
            }
            return i;
        }


        public IActionResult LoginUser()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                if (user.ConfirmPassword == user.UserPassword)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCmd = new SqlCommand("CreateUsers", sqlConnection);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("UserName", user.UserName);
                        sqlCmd.Parameters.AddWithValue("UserPassword", user.UserPassword);
                        sqlCmd.Parameters.AddWithValue("UserFullName", user.UserFullName);
                        sqlCmd.Parameters.Add("@checkUser", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sqlCmd.ExecuteNonQuery();
                        ViewBag.CountLog = sqlCmd.Parameters["@checkUser"].Value.ToString();

                    }

                    if (ViewBag.CountLog != "0")
                    {
                        user.UserLoginErrorMessage = "Username already exists!";

                    }
                    else
                    {

                        user.UserLoginErrorMessage = "You are successfully registered, user your username and password to login!";
                        return View("LoginUser",user);

                    }


                }

                else
                {
                    user.UserLoginErrorMessage = "The password does not match with ConfirmPassword!";
                }

            }
            return View(user);
        }


        [HttpPost]
        public IActionResult LoginUser(Users user, string returnUrl = null)
        {
            
            if (user.UserName is not null && user.UserPassword is not null)
            {
                if (ValidateUsers(user) == "1")
                {
                    var claims = new List<Claim>
                    {
                        new Claim("user", user.UserName),
                        new Claim("role","validUser")
                    };

                    //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var principal = new ClaimsPrincipal(identity);

                    //var props = new AuthenticationProperties();

                    //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,props).Wait();
                    HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "MyCookieUser", "user", "role")));

                    HttpContext.Session.SetString("User", user.UserName);

                    ///admin.LoginErrorMessage = "You are successfully logged in";

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/");
                    }


                }
                else
                {
                   user.UserLoginErrorMessage = "id or Password is wrong.!";
                }
            }
            return View(user);
        }

    }

}
