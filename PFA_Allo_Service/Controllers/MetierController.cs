using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;

namespace PFA_Allo_Service.Controllers
{
    public class MetierController : Controller
    {
		MyContext db;
		public MetierController(MyContext db)
		{
			this.db = db;
		}
		public IActionResult Index()
        {
			List<Metier> Metiers = db.Metiers.Include(m => m.Fournisseurs).ToList();
			return View(Metiers);
		}
		//GET: Services/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || db.Metiers == null)
			{
				return NotFound();
			}

			var metier = await db.Metiers
				.FirstOrDefaultAsync(m => m.MetierId == id);
			if (metier == null)
			{
				return NotFound();
			}

			return View(metier);
		}
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Metier m)
		{
			if (ModelState.IsValid)
			{
				db.Add(m);
				db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View();
		}
        public IActionResult Update(int id)
        {
            Metier m = db.Metiers.Where(m => m.MetierId == id).FirstOrDefault();
            if (m == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(m);
        }
        [HttpPost]
        public IActionResult Update(Metier m)
        {
            if (ModelState.IsValid)
            {
                Metier metier = db.Metiers.Where(ma => ma.MetierId == m.MetierId).FirstOrDefault();
                if (metier == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                metier.Categorie = m.Categorie;
                metier.Description = m.Description;
                metier.Photo = m.Photo;
                metier.Service = m.Service;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(m);
        }
        public IActionResult Delete(int id)
        {
            Metier m = db.Metiers.Where(m => m.MetierId == id).FirstOrDefault();
            if (m != null)
            {
                db.Metiers.Remove(m);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
