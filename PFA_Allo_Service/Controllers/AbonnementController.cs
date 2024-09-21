using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;

namespace PFA_Allo_Service.Controllers
{
    public class AbonnementController : Controller
    {
        MyContext db;
        public AbonnementController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Abonnement> abonnements = db.Abonnements.Include(a=>a.Fournisseurs).ToList();
            return View(abonnements);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AbonnementVM abonnementViewModel)
        {
            if (ModelState.IsValid)
            {
                // Vérifier si un abonnement du même type existe déjà
                var existingAbonnement = db.Abonnements.FirstOrDefault(a => a.Type_Abonnement == abonnementViewModel.Type_Abonnement);

                if (existingAbonnement != null)
                {
                    ModelState.AddModelError("Type_Abonnement", "Un abonnement de ce type existe déjà.");
                    return View(abonnementViewModel);
                }

                var abonnement = new Abonnement
                {
                    Date_Debut = abonnementViewModel.Date_Debut,
                    Type_Abonnement = abonnementViewModel.Type_Abonnement,
                };
                db.Abonnements.Add(abonnement);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(abonnementViewModel);
        }
        public IActionResult Update(int id)
        {
            Abonnement m = db.Abonnements.Where(m => m.AbonnementId == id).FirstOrDefault();
            if (m == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var abonnementVM = new AbonnementVM
            {
                Date_Debut = m.Date_Debut,
                Type_Abonnement = m.Type_Abonnement
            };

            return View(abonnementVM);
        }
        [HttpPost]
        public IActionResult Update(int id, AbonnementVM model)
        {
            if (ModelState.IsValid)
            {
                var abonnement = db.Abonnements.Find(id);
                if (abonnement == null)
                {
                    return NotFound();
                }

                // Vérifier si un abonnement du même type existe déjà (exclure l'abonnement actuel)
                var existingAbonnement = db.Abonnements
                                           .FirstOrDefault(a => a.Type_Abonnement == model.Type_Abonnement && a.AbonnementId != id);

                if (existingAbonnement != null)
                {
                    ModelState.AddModelError("Type_Abonnement", "Un abonnement de ce type existe déjà.");
                    return View(model);
                }

                abonnement.Date_Debut = model.Date_Debut;
                abonnement.Type_Abonnement = model.Type_Abonnement;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //public IActionResult Delete(int id)
        //{
        //    // Recherche l'abonnement avec ses paiements
        //    var abonnement = db.Abonnements.Include(a => a.Paiement).FirstOrDefault(a => a.AbonnementId == id);
        //    if (abonnement == null)
        //    {
        //        return NotFound();
        //    }

        //    // Vérifie si l'abonnement est référencé par d'autres entités, ici Fournisseur
        //    bool isReferenced = db.Fournisseurs.Any(f => f.AbonnementId == id);
        //    if (isReferenced)
        //    {
        //        // Annule la suppression et renvoie un message d'erreur
        //        ModelState.AddModelError( ,"Impossible de supprimer cet abonnement car il est référencé par un ou plusieurs fournisseurs.");
        //        return RedirectToAction(nameof(Index)); // Ou redirigez vers une vue appropriée
        //    }

        //    // Supprime les paiements associés s'ils existent
        //    if (abonnement.Paiement != null)
        //    {
        //        db.Paiements.Remove(abonnement.Paiement);
        //    }

        //    // Supprime l'abonnement
        //    db.Abonnements.Remove(abonnement);
        //    db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Delete(int id)
        {
            var abonnement = db.Abonnements.Include(a => a.Paiement).FirstOrDefault(a => a.AbonnementId == id);
            if (abonnement == null)
            {
                return Json(new { success = false, message = "Abonnement non trouvé." });
            }

            bool isReferenced = db.Fournisseurs.Any(f => f.AbonnementId == id);
            if (isReferenced)
            {
                return Json(new { success = false, message = "Impossible de supprimer cet abonnement car il est référencé par un ou plusieurs fournisseurs." });
            }

            if (abonnement.Paiement != null)
            {
                db.Paiements.Remove(abonnement.Paiement);
            }

            db.Abonnements.Remove(abonnement);
            db.SaveChanges();
            return Json(new { success = true, message = "Abonnement supprimé avec succès." });
        }
        public async Task<IActionResult> abonnement(int? id)
        {
            var abonnements = await db.Abonnements.ToListAsync();
            if (abonnements == null || !abonnements.Any())
            {
                ViewData["Message"] = "Aucun abonnement disponible.";
            }
            return View(abonnements);
        }
        public async Task<IActionResult> SelectAbonnement(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var abonnement = await db.Abonnements.FindAsync(id);
            if (abonnement == null)
            {
                return NotFound();
            }
            return RedirectToAction("Paiement", new { abonnementId = abonnement.AbonnementId });
        }
        public IActionResult Paiement(int abonnementId)
        {
            var paiement = new Paiement { AbonnementId = abonnementId };
            return View(paiement);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Paiement([Bind("PaiementId,Montant,Carte_Paiement,AbonnementId")] Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                db.Add(paiement);
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Paiement effectué avec succès.";
                return RedirectToAction("abonnement");
            }
            return View(paiement);
        }
    }
}