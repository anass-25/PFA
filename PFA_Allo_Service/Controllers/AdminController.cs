using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;
namespace PFA_Allo_Service.Controllers
{
    public class AdminController : Controller
    {
        MyContext db;
        public AdminController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard");
        }
		public IActionResult Gestion_Service()
		{
			return RedirectToAction("Index", "Service");
		}
        public IActionResult Gestion_Metier_Fournisseur()
        {
            var metiers = db.Metiers
                .Include(m => m.service)
                .Include(m => m.Fournisseurs)
                .Select(m => new
                {
                    Metier = m,
                    Service = m.service,
                    NombreFournisseurs = m.Fournisseurs.Count()
                }).ToList();

            return View(metiers);
        }
        public IActionResult MetiersPartial()
        {
            var metiers = db.Metiers
                .Include(m => m.service)
                .Include(m => m.Fournisseurs)
                .Select(m => new
                {
                    Metier = m,
                    Service = m.service,
                    NombreFournisseurs = m.Fournisseurs.Count()
                }).ToList();

            return PartialView("_MetiersTablePartial", metiers);
        }
        public IActionResult Gestion_Abonnement()
		{
			return RedirectToAction("Index", "Abonnement");
		}
        public IActionResult Gestion_Paiement()
        {
            return RedirectToAction("Index", "Paiement");
        }
        public IActionResult Pricing_Tables()
        {
            return View();
        }
    }
}
