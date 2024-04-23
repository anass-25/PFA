using Microsoft.AspNetCore.Mvc;

namespace PFA_Allo_Service.Controllers
{
    public class AccueilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
