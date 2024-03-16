using Microsoft.AspNetCore.Mvc;

namespace TemplatePFA.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
