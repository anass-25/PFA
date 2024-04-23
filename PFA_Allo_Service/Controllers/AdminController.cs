using Microsoft.AspNetCore.Mvc;

namespace PFA_Allo_Service.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Gestion_Service()
		{
			return RedirectToAction("Index", "Service");
		}
        public IActionResult Gestion_Metier_Fournisseur()
        {
            return RedirectToAction("Index","Metier");
        }
		public IActionResult Gestion_Abonnement()
		{
			return RedirectToAction("Index", "Abonnement");
		}
        public IActionResult Gestion_Paiement()
        {
            return RedirectToAction("Index", "Paiement");
        }
        public IActionResult General_Form()
        {
            return View();
        }
        public IActionResult Lister_Abonnement_Paiement()
        {
            return View();
        }
        public IActionResult Form_upload()
        {
            return View();
        }
        public IActionResult General_Elements()
        {
            return View();
        }
        public IActionResult Invoice()
        {
            return View();
        }
        public IActionResult Inbox()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        public IActionResult Table_Dynamic()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Pricing_Tables()
        {
            return View();
        }
        public IActionResult Page_403()
        {
            return View();
        }
        public IActionResult Page_404()
        {
            return View();
        }
        public IActionResult Page_500()
        {
            return View();
        }
    }
}
