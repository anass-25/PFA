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
            List<Abonnement> abonnements = db.Abonnements.ToList();
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
                var abonnement = new Abonnement
                {
                    Date_Debut = abonnementViewModel.Date_Debut,
                    Date_Fin = abonnementViewModel.Date_Fin,
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
            return View(m);
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
                abonnement.Type_Abonnement = model.Type_Abonnement;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
		public IActionResult Delete(int id)
		{
			Abonnement m = db.Abonnements.Where(m => m.AbonnementId == id).FirstOrDefault();
			if (m != null)
			{
				db.Abonnements.Remove(m);
				db.SaveChanges();
			}
			return RedirectToAction(nameof(Index));
		}

	}
}