using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PFA_Allo_Service.Controllers
{
    public class OffreController : Controller
    {
        private readonly MyContext db;
        public OffreController(MyContext db)
        {
            this.db = db;
        }
        //public IActionResult Add()
        //{
        //    int? userId = HttpContext.Session.GetInt32("Id");

        //    if (userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    ViewBag.Services = new SelectList(db.Services, "ServiceId", "Libelle");
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Add(Offre o, IFormFile MonImage)
        //{
        //    // Vérifier si l'utilisateur est authentifié et autorisé à ajouter une offre
        //    int? userId = HttpContext.Session.GetInt32("Id");
        //    if (userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var user = db.Users.FirstOrDefault(u => u.Id == userId.Value);
        //    if (user != null && user.UserType == "Fournisseur")
        //    {
        //        o.FournisseurId = userId.Value;

        //        if (MonImage != null && (MonImage.FileName.EndsWith(".jpeg") || MonImage.FileName.EndsWith(".jpg") || MonImage.FileName.EndsWith(".png")) && MonImage.Length < 1000000)
        //        {
        //            // Générer un nom de fichier unique en ajoutant un GUID au nom d'origine du fichier
        //            string fileName = Guid.NewGuid().ToString() + "_" + MonImage.FileName;

        //            // Chemin complet où enregistrer le fichier avec le nom unique
        //            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

        //            // Enregistrer le fichier avec le nom unique
        //            using (var fileStream = new FileStream(path, FileMode.Create))
        //            {
        //                await MonImage.CopyToAsync(fileStream);
        //            }

        //            // Enregistrer le nom de fichier unique dans le modèle
        //            o.Photo = fileName;

        //            // Ajouter l'offre à la base de données
        //            db.Offres.Add(o);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Gestion_Offre", "Fournisseur");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Le fichier doit être une image JPEG, JPG ou PNG et ne doit pas dépasser 100000 octets.");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Seuls les fournisseurs peuvent ajouter des offres.");
        //    }

        //    ViewBag.Services = new SelectList(db.Services, "ServiceId", "Libelle");
        //    return View(o);
        //}
        public IActionResult Add()
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return Unauthorized();
            }

            var user = db.Users.FirstOrDefault(u => u.Id == userId.Value);
            bool isSubscribed = false;
            if (user != null && user.UserType == "Fournisseur")
            {
                var fournisseur = db.Fournisseurs.FirstOrDefault(f => f.Id == userId.Value);
                isSubscribed = fournisseur?.AbonnementId != null;
            }

            ViewBag.Services = new SelectList(db.Services, "ServiceId", "Libelle");
            ViewBag.IsSubscribed = isSubscribed;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Offre o, IFormFile MonImage)
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            if (userId == null)
            {
                return Unauthorized();
            }

            var user = db.Users.FirstOrDefault(u => u.Id == userId.Value);
            if (user != null && user.UserType == "Fournisseur")
            {
                var fournisseur = db.Fournisseurs.FirstOrDefault(f => f.Id == userId.Value);
                bool isSubscribed = fournisseur?.AbonnementId != null;
                ViewBag.IsSubscribed = isSubscribed;

                if (!isSubscribed)
                {
                    ModelState.AddModelError(string.Empty, "Vous devez vous abonner pour ajouter une offre.");
                }
                else
                {
                    o.FournisseurId = userId.Value;

                    if (MonImage != null && (MonImage.FileName.EndsWith(".jpeg") || MonImage.FileName.EndsWith(".jpg") || MonImage.FileName.EndsWith(".png")) && MonImage.Length < 1000000)
                    {
                        string fileName = Guid.NewGuid().ToString() + "_" + MonImage.FileName;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await MonImage.CopyToAsync(fileStream);
                        }

                        o.Photo = fileName;
                        db.Offres.Add(o);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Gestion_Offre", "Fournisseur");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Le fichier doit être une image JPEG, JPG ou PNG et ne doit pas dépasser 100000 octets.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Seuls les fournisseurs peuvent ajouter des offres.");
            }

            ViewBag.Services = new SelectList(db.Services, "ServiceId", "Libelle");
            return View(o);
        }
        public IActionResult Update(int Id)
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return Unauthorized();
            }

            ViewBag.Services = new SelectList(db.Services, "ServiceId", "Libelle");
            Offre o = db.Offres.FirstOrDefault(o => o.OffreId == Id);
            if (o == null || o.FournisseurId != userId.Value)
            {
                return RedirectToAction("Index");
            }

            // Convertir Offre en OffreVM
            var offreVM = new OffreVM
            {
                OffreId = o.OffreId,
                Prix = o.Prix,
                Photo = o.Photo,
                Description = o.Description,
                Date_Debut = o.Date_Debut,
                Date_Fin = o.Date_Fin,
                Titre = o.Titre
            };

            return View(offreVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id, OffreVM o, IFormFile MonImage)
        {
            // Vérifier si l'utilisateur est authentifié et autorisé à modifier l'offre
            int? userId = HttpContext.Session.GetInt32("Id");
            if (userId == null)
            {
                return Unauthorized();
            }

            // Récupérer l'offre à mettre à jour
            var Off = db.Offres.Find(Id);
            if (Off == null)
            {
                return NotFound();
            }

            // Vérifier si l'utilisateur est le fournisseur de cette offre
            if (Off.FournisseurId != userId)
            {
                return Unauthorized(); // Ou une autre logique pour gérer l'autorisation
            }

            if (o != null)
            {
                if (MonImage != null && (MonImage.FileName.EndsWith(".jpeg") || MonImage.FileName.EndsWith(".jpg") || MonImage.FileName.EndsWith(".png")) && MonImage.Length < 1000000)
                {
                    // Générer un nom de fichier unique en ajoutant un GUID au nom d'origine du fichier
                    string fileName = Guid.NewGuid().ToString() + "_" + MonImage.FileName;

                    // Chemin complet où enregistrer le fichier avec le nom unique
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                    // Enregistrer le fichier avec le nom unique
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await MonImage.CopyToAsync(fileStream);
                    }

                    // Supprimer l'ancienne photo si elle existe
                    if (!string.IsNullOrEmpty(Off.Photo))
                    {
                        string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Off.Photo);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Enregistrer le nom de fichier unique dans le modèle
                    Off.Photo = fileName;
                }

                // Mettre à jour les autres propriétés de l'offre
                Off.Prix = o.Prix;
                Off.Description = o.Description;
                Off.Date_Debut = o.Date_Debut;
                Off.Date_Fin = o.Date_Fin;
                Off.Titre = o.Titre;

                // Enregistrer les modifications dans la base de données
                await db.SaveChangesAsync();
                return RedirectToAction("Gestion_Offre", "Fournisseur");
            }

            ViewBag.Services = new SelectList(db.Services, "ServiceId", "Libelle");
            return View(o);
        }
        public IActionResult Delete(int Id)
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return Unauthorized();
            }

            var o = db.Offres.FirstOrDefault(o => o.OffreId == Id);
            if (o != null && o.FournisseurId == userId)
            {
                if (!string.IsNullOrEmpty(o.Photo))
                {
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", o.Photo);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                db.Offres.Remove(o);
                db.SaveChanges();
            }
            return RedirectToAction("Gestion_Offre", "Fournisseur");
        }
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return Unauthorized();
            }

            // Récupérer les offres pour le fournisseur actuellement authentifié
            var offres = db.Offres.Where(o => o.FournisseurId == userId.Value).ToList();
            return View(offres);
        }
    }
}