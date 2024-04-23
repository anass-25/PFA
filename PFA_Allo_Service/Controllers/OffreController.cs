using Microsoft.AspNetCore.Mvc;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;

namespace PFA_Allo_Service.Controllers
{
    public class OffreController : Controller
    {
        MyContext db;
        public OffreController(MyContext db)     //constructeur de MyControlleur,  c est injectiion de depondance , traivaille  de my conr=texte sans instancier pour eviter coplage fort
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Offre> offres = db.Offres/*.Include(o => o.Fournisseur)*/.ToList();

            return View(offres);
        }
        public IActionResult Add()

        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(OffreVM o)
        {
            if (ModelState.IsValid)
            {
                Offre offre = new Offre();
                offre.Prix = o.Prix;
                offre.Photo = o.Photo;
                offre.Description = o.Description;
                offre.Date_Debut = o.Date_Debut;
				offre.Date_Fin = o.Date_Fin;
				offre.Titre = o.Titre;
                db.Offres.Add(offre);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
		public IActionResult Update(int Id)
		{
			Offre o = db.Offres.Where(o => o.OffreId == Id).FirstOrDefault();
			if (o == null)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(o);
		}

		[HttpPost]
		public IActionResult Update(int Id, OffreVM o)
		{
			if (ModelState.IsValid)
			{
				var Off = db.Offres.Find(Id);
				if (Off == null)
				{
					return NotFound();
				}
				Off.Prix = o.Prix;
				Off.Photo = o.Photo;
				Off.Description = o.Description;
				Off.Date_Debut = o.Date_Debut;
				Off.Date_Fin = o.Date_Fin;
				Off.Titre = o.Titre;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(o);
		}
		public IActionResult Delete(int Id)
		{
			Offre o = db.Offres.Where(o => o.OffreId == Id).FirstOrDefault();
			if (o != null)
			{
				db.Offres.Remove(o);
				db.SaveChanges(true);
			}
			return RedirectToAction(nameof(Index));

		}
	}
}
