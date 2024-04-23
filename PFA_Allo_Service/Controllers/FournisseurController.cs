using Microsoft.AspNetCore.Mvc;
using PFA_Allo_Service.Models;

namespace PFA_Allo_Service.Controllers
{
    public class FournisseurController : Controller
    {
        MyContext db;

        public FournisseurController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Gestion_Offre() 
        {
            return RedirectToAction("Index","Offre");
        }
        [HttpGet]
        public IActionResult Subscribe(int abonnementId)
        {
            var abonnement = db.Abonnements.Find(abonnementId);
            if (abonnement == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("AbonnementId", abonnementId);
            return View(abonnement);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubscribeConfirmation()
        {
            var abonnementId = HttpContext.Session.GetInt32("AbonnementId");
            if (abonnementId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var fournisseurId = HttpContext.Session.GetInt32("FournisseurId");
            if (fournisseurId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Session.Remove("AbonnementId");
            return RedirectToAction("SubscriptionConfirmation");
        }
    }
}
