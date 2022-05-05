using Microsoft.AspNetCore.Mvc;
using SortableCollection.Models;
using System.Diagnostics;


namespace SortableCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sortOrder)
        {
            sortOrder = string.IsNullOrEmpty(sortOrder) ? "id" : sortOrder;
            var contacts = new[]
     {
        new Contact{Id = 1, Name="dave", City="Seattle", State="WA", Phone="123"},
        new Contact{Id = 2, Name="mike", City="Spokane", State="WA", Phone="234"},
        new Contact{Id = 3, Name="lisa", City="San Jose", State="CA", Phone="345"},
        new Contact{Id = 4, Name="cathy", City="Dallas", State="TX", Phone="456"},
    };
            
            var c= contacts.AsQueryable();
            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "id":
                        {
                            c = c.OrderBy(x => x.Id);
                            break;
                        }
                    case "name":
                        {
                            c=c.OrderBy(x => x.Name);
                            break;
                        }
                    case "city":
                        {c=c.OrderBy(x => x.City);
                            break;
                        }
                    case "state":
                        {c=c.OrderBy(x => x.State);
                            break;
                        }
                    case "phone":
                        {c=c.OrderBy(x => x.Phone);
                            break;
                        }
                }
            }

            return View(c);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}