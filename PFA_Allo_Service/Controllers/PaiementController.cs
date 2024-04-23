using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;
using System.Collections.Generic;

namespace PFA_Allo_Service.Controllers
{
    public class PaiementController : Controller
    {
        private readonly MyContext context; // Replace with your DbContext class name


        public PaiementController(MyContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var paiements = context.Paiements.ToList();
            return View(paiements);
        }
        public IActionResult ProcessPayment()
        {
			ViewBag.Abonnements = context.Abonnements.ToList();
			return View();
        }
        [HttpPost]
        public IActionResult ProcessPayment(PaiementVM paiementvm)
        {
            if (ModelState.IsValid)
            {
                Paiement paiement = new Paiement();

                //paiement.Type_Abonnement = paiementvm.Type_Abonnement;
                paiement.Montant = paiementvm.Montant;
                paiement.Carte_Paiement = paiementvm.Carte_Paiement;
                paiement.AbonnementId = paiementvm.AbonnementId;

				context.Paiements.Add(paiement);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ProcessPayment));                        
        }
        public IActionResult Delete(int id)
        {
            Paiement p = context.Paiements.Where(p => p.PaiementId == id).FirstOrDefault();
            if (p != null)
            {
                context.Paiements.Remove(p);
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
