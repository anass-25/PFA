//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using PFA_Allo_Service.Models;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;

//namespace PFA_Allo_Service.Controllers
//{
//	public class MetierController : Controller
//	{
//		private readonly MyContext db;

//		public MetierController(MyContext db)
//		{
//			this.db = db;
//		}

//		public IActionResult Add()
//		{
//			ViewBag.Services = db.Services.ToList();
//			return View();
//		}

//		[HttpPost]
//		public async Task<IActionResult> AddAsync(Metier m, IFormFile MonImage)
//		{
//			ViewBag.Services = new SelectList(db.Services, "ServiceId", "Libelle");

//			if (MonImage != null && (MonImage.FileName.ToLower().EndsWith(".jpeg") || MonImage.FileName.ToLower().EndsWith(".jpg") || MonImage.FileName.ToLower().EndsWith(".png")) && MonImage.Length < 1000000)
//			{
//				m.Photo = MonImage.FileName;
//				string p = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", MonImage.FileName);
//				using (var file = new FileStream(p, FileMode.Create))
//				{
//					await MonImage.CopyToAsync(file);
//				}

//				db.Add(m);
//				await db.SaveChangesAsync();
//				return RedirectToAction("Metier", "Accueil");
//			}
//			return View(m);
//		}
//	}
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PFA_Allo_Service.Models;

namespace PFA_Allo_Service.Controllers
{
    public class MetierController : Controller
    {
        private readonly MyContext _db;

        public MetierController(MyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Metier> Metiers = _db.Metiers.Include(m => m.Fournisseurs).Include(m => m.service).ToList();
            return View(Metiers);
        }



        public IActionResult Add()
        {
            ViewBag.Services = _db.Services.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Metier m, IFormFile MonImage)
        {
            if (MonImage != null && (MonImage.FileName.ToLower().EndsWith(".jpeg") || MonImage.FileName.ToLower().EndsWith(".jpg") || MonImage.FileName.ToLower().EndsWith(".png")) && MonImage.Length < 1000000)
            {
                m.Photo = MonImage.FileName;
                string p = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", MonImage.FileName);
                using (var file = new FileStream(p, FileMode.Create))
                {
                    await MonImage.CopyToAsync(file);
                }

                _db.Add(m);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(m);
        }

        public IActionResult Update(int id)
        {
            Metier m = _db.Metiers.Include(m => m.service).Where(m => m.MetierId == id).FirstOrDefault();
            if (m == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Services = _db.Services.ToList();
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Metier m, IFormFile NewPhoto)
        {
            Metier metier = _db.Metiers.Where(ma => ma.MetierId == m.MetierId).FirstOrDefault();
            if (metier == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (NewPhoto != null && (NewPhoto.FileName.ToLower().EndsWith(".jpeg") || NewPhoto.FileName.ToLower().EndsWith(".jpg") || NewPhoto.FileName.ToLower().EndsWith(".png")) && NewPhoto.Length < 1000000)
            {
                string p = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", NewPhoto.FileName);
                using (var file = new FileStream(p, FileMode.Create))
                {
                    await NewPhoto.CopyToAsync(file);
                }
                metier.Photo = NewPhoto.FileName;
            }

            metier.Categorie = m.Categorie;
            metier.Description = m.Description;
            metier.service = m.service;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Metier m = _db.Metiers.Where(m => m.MetierId == id).FirstOrDefault();
            if (m != null)
            {
                _db.Metiers.Remove(m);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}