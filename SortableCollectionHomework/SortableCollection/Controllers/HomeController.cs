using Microsoft.AspNetCore.Mvc;
using SortableCollection.Models;
using System.Diagnostics;


namespace SortableCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IContactRepository  _contactRepo;
        public HomeController(ILogger<HomeController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepo = contactRepository;
        }

        public IActionResult Index(string sortOrder)
        {
            sortOrder = string.IsNullOrEmpty(sortOrder) ? "id" : sortOrder;
            var contacts = _contactRepo.contact;
            
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