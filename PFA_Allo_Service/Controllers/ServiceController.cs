using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;

namespace PFA_Allo_Service.Controllers
{
	public class ServiceController : Controller
	{
		MyContext db;
		public ServiceController(MyContext db) 
		{
			this.db = db;
		}
		public IActionResult Index()
		{
			List<Service> services = db.Services.Include(s => s.metiers).ToList();
			return View(services);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(ServiceVM svm)
		{
            if (ModelState.IsValid)
            {
				Service service = new Service();
				service.Libelle = svm.Libelle;
				service.Description = svm.Description;
				service.Photo = svm.Photo;
				db.Services.Add(service);
				db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
		}
		public IActionResult Update(int id)
		{
            Service s = db.Services.Where(s => s.ServiceId == id).FirstOrDefault();
			if (s == null)
			{
				return RedirectToAction(nameof(Index));
			}
            return View(s);
		}
		[HttpPost]
		public IActionResult Update(int id, ServiceVM s)
		{
			if (ModelState.IsValid)
			{
				Service service = db.Services.Find(id);
				if (service == null)
				{
					return RedirectToAction(nameof(Index));
				}
				service.Libelle = s.Libelle;
				service.Description = s.Description;
				service.Photo = s.Photo;
				//db.Services.Update(service);
				db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(s);
		}
		public IActionResult Delete(int id)
		{
			Service s = db.Services.Where(s => s.ServiceId == id).FirstOrDefault();
			if (s != null)
			{
				db.Services.Remove(s);
				db.SaveChanges();
			}
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Lister_Fournisseur(int id)
		{

			return View();
		}
		public IActionResult Metiers(int serviceId)
		{
			var service = db.Services.Include(s => s.metiers).FirstOrDefault(s => s.ServiceId == serviceId);
			if (service == null)
			{
				return NotFound();
			}
			var metiers = service.metiers.ToList(); // Récupérer la liste des métiers associés au service

			return View(metiers);
		}
	}
}
