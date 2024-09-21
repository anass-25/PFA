using Microsoft.AspNetCore.Mvc;

namespace PFA_Allo_Service.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index","Accueil");
        }
		public IActionResult Demande_Service()
		{
			return View();
		}
	}
}
