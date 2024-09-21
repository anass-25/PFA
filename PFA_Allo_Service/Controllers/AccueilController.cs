using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;
using System.Security.Claims;

namespace PFA_Allo_Service.Controllers
{
    public class AccueilController : Controller
    {
        MyContext db;
        public AccueilController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Visiteur et Client
        public IActionResult Offre()
        {
            List<Offre> offres = db.Offres.Include(o => o.Fournisseur).OrderByDescending(o => o.OffreId).ToList();

            // Pass data to the view
            ViewData["Offres"] = offres;

            return View(offres);
		}
        //Fournisseur et Client et Visiteur
        public IActionResult FournisseurOffres(int fournisseurId)
		{
			var offres = db.Offres.Include(o => o.Fournisseur)
								  .Where(o => o.FournisseurId == fournisseurId)
								  .OrderByDescending(o => o.OffreId)
								  .ToList();

			if (offres == null || offres.Count == 0)
			{
				return NotFound("Aucune offre trouvée pour ce fournisseur.");
			}

			return View(offres);
		}
        //Client et Visiteur
		public IActionResult Services()
        {
            List<Service> services = db.Services /*.Include(o => o.Fournisseur)*/.ToList();

            // Pass data to the view
            ViewData["Services"] = services;

            return View(services);
        }
        //Visiteur Client
        public IActionResult Metier()
        {
            var metiers = db.Metiers.Include(m => m.service)
                                     .OrderByDescending(m => m.MetierId) // Tri par MetierId, les plus récents en premier
                                     .ToList();
            ViewData["Metiers"] = metiers;

            if (metiers == null || metiers.Count == 0)
            {
                return NotFound("Aucun métier trouvé.");
            }

            return View(metiers);
        }
        public IActionResult Contact()
        {
            return View();
        }
        //Client
        public IActionResult IndexAvis()
        {
            List<Avis> avies = db.Avis.ToList();
            // List<AvisVM> avies = db.Avies.Select(p => new AvisVM(p)).ToList();
            return View(avies);
        }
        //Client
        public IActionResult Add()
        {
            // Récupérez l'utilisateur actuel depuis la base de données
            int id = (int)HttpContext.Session.GetInt32("Id");
            var user = db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View();

        }
        [HttpPost]
        public IActionResult Add(AvisVM av)
        {
            if (ModelState.IsValid)
            {
                int? userId = HttpContext.Session.GetInt32("Id"); // Utiliser int? pour permettre la valeur null
                if (userId != null)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    Avis avis = new Avis();

                    if (user != null)
                    {
                        if (user.UserType == "Client")
                        {
                            avis.ClientId = userId.Value; // Utiliser .Value pour accéder à la valeur entière
                        }
                        else if (user.UserType == "Fournisseur")
                        {
                            avis.FournisseurId = userId.Value; // Utiliser .Value pour accéder à la valeur entière
                        }

                        avis.Note = av.Note;
                        avis.Date_Heures = av.Date_Heures;
                        avis.Commentaire = av.Commentaire;
                        avis.Show = av.Show;
                        db.Avis.Add(avis);
                        db.SaveChanges();

                        return RedirectToAction("IndexAvis", "Accueil");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound(); // Ou une autre action pour gérer l'absence d'utilisateur authentifié
                }
            }

            return View(av);
        }
        public IActionResult Update(int Id)
        {
            Avis a = db.Avis.Where(a => a.AvisId == Id).FirstOrDefault();
            if (a == null)
            {
                return RedirectToAction("IndexAvis", "Accueil");
            }
            return View(a);
        }
        [HttpPost]
        public IActionResult Update(int Id, AvisVM a)
        {
            if (ModelState.IsValid)
            {
                var Avv = db.Avis.Find(Id);
                if (Avv == null)
                {
                    return NotFound();
                }
                Avv.Note = a.Note;
                Avv.Date_Heures = a.Date_Heures;
                Avv.Commentaire = a.Commentaire;
                Avv.Show = a.Show;

                db.SaveChanges();
                return RedirectToAction("IndexAvis", "Accueil");
            }
            return View(a);
        }
        public IActionResult Delete(int Id)
        {
            Avis a = db.Avis.Where(a => a.AvisId == Id).FirstOrDefault();
            if (a != null)
            {
                db.Avis.Remove(a);
                db.SaveChanges(true);
            }
            return RedirectToAction("IndexAvis", "Accueil");

        }
        //Client et Visiteur
        public IActionResult ListeFournisseurs(int metierId)
        {
            List<Fournisseur> fournisseurs = db.Users.OfType<Fournisseur>()
                                                     .Include(f => f.metier)
                                                     .Include(f => f.Avis)
                                                     .Where(f => f.metier.MetierId == metierId)
                                                     .ToList();

            ViewData["Fournisseurs"] = fournisseurs;
            List<Offre> offres = db.Offres.Include(o => o.Fournisseur).OrderByDescending(o => o.OffreId).ToList();

            // Pass data to the view
            ViewData["Offres"] = offres;
            return View(fournisseurs);  // Pass the list directly to the view
        }
        public IActionResult Fournisseurs()
        {
            List<Fournisseur> fournisseurs = db.Users.OfType<Fournisseur>()
                                                     .Include(f => f.metier)
                                                     .Include(f => f.Avis)
                                                     .ToList();

            ViewData["Fournisseurs"] = fournisseurs;

            return View(fournisseurs);  // Pass the list directly to the view
        }
    }
}

