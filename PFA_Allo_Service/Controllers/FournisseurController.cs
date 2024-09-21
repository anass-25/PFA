using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;
using System.Security.Claims;

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
        public IActionResult Gestion_Offre() 
        {
            int? fournisseurId = HttpContext.Session.GetInt32("Id");
            if (fournisseurId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var offres = db.Offres
                                 .Include(o => o.Fournisseur)
                                 .Where(o => o.FournisseurId == fournisseurId)
                                 .ToList();

            return View(offres);
        }
        public async Task<IActionResult> Abonnement()
        {
            var abonnements = await db.Abonnements
                .Include(a => a.Paiement)
                .ToListAsync();
            return View(abonnements);
        }
        [HttpPost]
        public async Task<IActionResult> ChoisirAbonnement(int AbonnementId)
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            if (userId == null)
            {
                return Unauthorized();
            }

            var abonnement = await db.Abonnements
                .FirstOrDefaultAsync(a => a.AbonnementId == AbonnementId);

            if (abonnement == null)
            {
                return NotFound();
            }

            var fournisseur = await db.Fournisseurs.FirstOrDefaultAsync(f => f.Id == userId.Value);

            if (fournisseur == null)
            {
                return NotFound();
            }

            fournisseur.Abonnement = abonnement;
            abonnement.Fournisseurs ??= new List<Fournisseur>();
            abonnement.Fournisseurs.Add(fournisseur);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Paiement), new { AbonnementId = abonnement.AbonnementId }); // Redirige vers l'action Paiement
        }
    }
}
