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
            var paiements = context.Paiements.Include(p => p.Abonnement).ToList();
            return View(paiements);
        }
        //      public IActionResult ProcessPayment()
        //      {
        //	ViewBag.Abonnements = context.Abonnements.ToList();
        //	return View();
        //      }
        //[HttpPost]
        //      public IActionResult ProcessPayment(PaiementVM paiementvm)
        //      {
        //          if (ModelState.IsValid)
        //          {
        //              Paiement paiement = new Paiement
        //              {
        //                  Montant = paiementvm.Montant,
        //                  AbonnementId = paiementvm.AbonnementId
        //              };

        //              context.Paiements.Add(paiement);
        //              context.SaveChanges();

        //              return RedirectToAction(nameof(Index));
        //          }
        //          ViewBag.Abonnements = context.Abonnements.ToList();
        //          return View(paiementvm);
        //      }
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
                // Check if the AbonnementId already exists in the Paiements table
                bool abonnementExists = context.Paiements.Any(p => p.AbonnementId == paiementvm.AbonnementId);

                if (abonnementExists)
                {
                    ModelState.AddModelError("AbonnementId", "Cet abonnement a déjà un paiement associé.");
                }
                else
                {
                    Paiement paiement = new Paiement
                    {
                        Montant = paiementvm.Montant,
                        AbonnementId = paiementvm.AbonnementId
                    };

                    context.Paiements.Add(paiement);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.Abonnements = context.Abonnements.ToList();
            return View(paiementvm);
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
