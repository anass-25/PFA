using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA_Allo_Service.Models;

namespace PFA_Allo_Service.Controllers
{
    public class ReclamationController : Controller
    {
        // DbContext pour accéder à la base de données
        private readonly MyContext _db;
        // Constructeur pour injecter le DbContext
        public ReclamationController(MyContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Récupérez l'utilisateur actuel depuis la base de données
            int id = (int)HttpContext.Session.GetInt32("Id");
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            else if (user.UserType != "Fournisseur" && user.UserType != "Client")  // le cas de admin qui  vu la liste de reclamation
            {
                // Récupérer la liste des réclamations depuis la base de données
                // var reclamations = _db.Reclamations.Include(u=>u.FournisseurId || u=>u.ClientId).ToList();
                var reclamations = _db.Reclamations.Include(r => r.Fournisseur) // Inclure l'entité Fournisseur
                                    .Include(r => r.Client)      // Inclure l'entité Client
                                    .ToList();


                // Passez les réclamations à la vue Index pour l'affichage
                return View(reclamations);

            }


            return View();


        }
        public IActionResult Create()
        {
            // Récupérez l'utilisateur actuel depuis la base de données
            int? userId = HttpContext.Session.GetInt32("Id");
            if (userId == null)
            {
                return NotFound();
            }

            var user = _db.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            // Stockez le type d'utilisateur dans ViewData pour le passer à la vue
            ViewData["UserType"] = user.UserType;

            return View();
        }
        //public IActionResult Create()
        //{
        //    // Récupérez l'utilisateur actuel depuis la base de données
        //    int id = (int)HttpContext.Session.GetInt32("Id");
        //    var user = _db.Users.FirstOrDefault(u => u.Id == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }


        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Reclamation Vm)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        //  pour  Client id Ou fornisseur Id  c est le compte ecrire reclamation
        //        int id = (int)HttpContext.Session.GetInt32("Id");
        //        var user = _db.Users.FirstOrDefault(u => u.Id == id); // pour recuperer tous  lq ligne de ce Id:

        //        //Reclamation repondReclamation = new Reclamation();
        //        Reclamation reclamation = new Reclamation();
        //        if (user.UserType == "Client")
        //        {
        //            reclamation.ClientId = id;

        //        }
        //        else if (user.UserType == "Fournisseur")
        //        {
        //            reclamation.FournisseurId = id;

        //        }
        //        // Ajoutez la description à la réclamation
        //        reclamation.Description = Vm.Description;
        //        // Ajoute la nouvelle réclamation à la base de données
        //        _db.Reclamations.Add(reclamation); // Ajoute d'abord la réclamation client/fournisseur
        //                                           //_db.Reclamations.Add(Vm); // Ajoute ensuite la nouvelle réclamation
        //                                           // Enregistre les changements dans la base de données
        //        _db.SaveChanges();

        //        // Redirige vers l'action Index
        //        // return RedirectToAction(nameof(Index));
        //        return RedirectToAction("Index", "Accueil");
        //    }

        //    return View(Vm);

        //}
        [HttpPost]
        public IActionResult Create(Reclamation Vm)
        {
            if (ModelState.IsValid)
            {
                // Récupérez l'utilisateur actuel depuis la base de données
                int id = (int)HttpContext.Session.GetInt32("Id");
                var user = _db.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound();
                }

                // Créez une nouvelle réclamation
                Reclamation reclamation = new Reclamation
                {
                    Description = Vm.Description
                };

                // Affectez l'ID client ou fournisseur en fonction du type d'utilisateur
                if (user.UserType == "Client")
                {
                    reclamation.ClientId = id;
                    _db.Reclamations.Add(reclamation);
                    _db.SaveChanges();

                    // Redirigez vers l'action Index
                    return RedirectToAction("Index", "Accueil");
                }
                else if (user.UserType == "Fournisseur")
                {
                    reclamation.FournisseurId = id;
                    _db.Reclamations.Add(reclamation);
                    _db.SaveChanges();

                    // Redirigez vers l'action Index
                    return RedirectToAction("Index", "Fournisseur");
                }
            }

            // Si le modèle n'est pas valide, passez le type d'utilisateur à la vue pour définir le bon layout
            int? userId = HttpContext.Session.GetInt32("Id");
            var currentUser = _db.Users.FirstOrDefault(u => u.Id == userId);
            if (currentUser != null)
            {
                ViewData["UserType"] = currentUser.UserType;
            }

            return View(Vm);
        }
        public IActionResult Delete(int id)
        {
            //int id = (int)HttpContext.Session.GetInt32("Id");
            // Recherchez la réclamation à supprimer dans la base de données
            var reclamation = _db.Reclamations.FirstOrDefault(r => r.ReclamationId == id);

            // Vérifiez si la réclamation existe
            if (reclamation == null)
            {
                // Si la réclamation n'existe pas, retournez une vue NotFound
                return NotFound();
            }

            // Si la réclamation existe, supprimez-la de la base de données
            _db.Reclamations.Remove(reclamation);
            _db.SaveChanges();

            // Redirigez l'utilisateur vers l'action Index après la suppression
            return RedirectToAction(nameof(Index));
            return View();
        }
        /*   public IActionResult Repondre()
           {
               // Récupérez l'utilisateur actuel depuis la base de données
               int id = (int)HttpContext.Session.GetInt32("Id");
               var user = _db.Users.FirstOrDefault(u => u.Id == id);


               if (user == null)
               {
                   return NotFound();
               }

               return View();
           }

           [HttpPost]
           public IActionResult Repondre(int _id, RepondreReclamationVm vm)
           {
               if (ModelState.IsValid)
               {
                   //  pour  Client id Ou fornisseur Id  c est le compte ecrire reclamation
                   int id = (int)HttpContext.Session.GetInt32("Id");
                   var user = _db.Users.FirstOrDefault(u => u.Id == id); // pour recuperer tous  lq ligne de ce Id:
                   //var ReclamationId =_db.Reclamations.FirstOrDefault(u => u.ReclamationId == _id);
                   var ReclamationId = _db.Reclamations.FirstOrDefault(r => r.ReclamationId == _id);

                   Reclamation repondReclamation = new Reclamation();

                   if (user.UserType == "Client")
                   {
                       repondReclamation.ClientId = id;

                   }
                   else if (user.UserType == "Fournisseur")
                   {
                       repondReclamation.FournisseurId = id;

                   }
                   else
                   {
                       repondReclamation.AdministrateurId = id;
                       //ReclamationId.ReclamationId = _id;
                       repondReclamation.repondReclamation = vm.repondReclamation;
                       //repondReclamation.ReclamationId = id.re
                   }
                   // Assurez-vous que la description n'est pas nulle
                   if (!string.IsNullOrEmpty(vm.repondReclamation))
                   {
                       repondReclamation.AdministrateurId = id;
                       _db.Reclamations.Add(repondReclamation);
                       //_db.Reclamations.Add(ReclamationId);

                       _db.SaveChanges();
                   }
                   else
                   {
                       // Gérez le cas où la description est nulle ou vide
                       // Vous pouvez retourner une vue avec un message d'erreur ou prendre une autre action appropriée
                       return View();
                   }
                   // Ajoutez la description à la réclamation

                   repondReclamation.repondReclamation = vm.repondReclamation;
                   Reclamation reclamation = new Reclamation();
                   // Ajoute la nouvelle réclamation à la base de données
                   _db.Reclamations.Add(repondReclamation);
                   _db.SaveChanges();



               }
               return View();
           }
        */
    }
}

