using Microsoft.AspNetCore.Mvc;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;

namespace PFA_Allo_Service.Controllers
{
    public class UsersController : Controller
    {
        //private static string Email;
        MyContext db;
        public UsersController(MyContext db) 
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                //var user = _context.Login(email, password);
                //if (user != null)
                //{
                //    HttpContext.Session.SetString("Id", Id);
                //    // Authentication successful, redirect to dashboard or desired page
                //    return RedirectToAction("Index", "Home");
                //}
                User user = db.Users.FirstOrDefault(u => u.Email == email && u.Mot_de_Passe == password);
                if (user != null)
                {
                    if (user.UserType == "Client" || user.UserType == "Fournisseur")
                    {
                        int userId = user.Id; // Assuming the user object has an 'Id' property
                        HttpContext.Session.SetInt32("Id", userId);
                        HttpContext.Session.SetString("Email", user.Email);
                        HttpContext.Session.SetString("Nom", user.Nom);
                        HttpContext.Session.SetString("Prenom", user.Prenom);
                        HttpContext.Session.SetString("Role", user.UserType);
                        // Authentication successful, redirect to dashboard or desired page
                        return RedirectToAction("Index", "Accueil");
                    }
                    else
                    {
                        int id = user.Id; // Assuming the user object has an 'Id' property
                        HttpContext.Session.SetInt32("Id", id);
                        HttpContext.Session.SetString("Email", user.Email);
                        HttpContext.Session.SetString("Nom", user.Nom);
                        HttpContext.Session.SetString("Prenom", user.Prenom);
                        HttpContext.Session.SetString("Role", user.UserType);
                        // Authentication successful, redirect to dashboard or desired page
                        return RedirectToAction("Index", "Admin");
                    }

                }
                else
                {
                    // Authentication failed, display error message
                    ViewBag.ErrorMessage = "Invalid email or password.";
                    return View();
                }
            }
            else
            {
                // Model state is not valid, redisplay the login form with validation errors
                return View();
            }
        }
        public IActionResult UsersInscription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UsersInscription(InscriptionVM vm)
        {
            if (ModelState.IsValid)
            {
                // verifier que le login(email) est unique
                int count = db.Users.Where(us => us.Email == vm.Email).Count();
                if (count == 0)
                {
                    User u = new User();
                    u.Nom = vm.Nom;
                    u.Prenom = vm.Prenom;
                    u.CIN = vm.CIN;
                    u.Telephone = vm.Telephone;
                    u.Email = vm.Email;
                    u.Mot_de_Passe = vm.Mot_de_Passe;
                    u.UserType = vm.Role;
                    
                    db.Users.Add(u);
                    db.SaveChanges();
                    HttpContext.Session.SetInt32("Id", u.Id);
                    HttpContext.Session.SetString("Nom", u.Nom);
                    HttpContext.Session.SetString("Prenom", u.Prenom);
                    HttpContext.Session.SetString("Email", u.Email);
                    HttpContext.Session.SetString("Role", u.UserType);
                    return RedirectToAction("Index", "Accueil"); // Produit za3ma mnin  nsaliw inscription yadini l had class Produit ri example 
                }
                ModelState.AddModelError("Email", "Email existe deja "); // anotation pour email deja existe il s'appelle annotation unique



            }
            return View();
        }
        //public IActionResult FournInscription()
        //{
        //    return View();
        //}
        //public IActionResult CLientInscription()
        //{
        //    return View();
        //}       
        public IActionResult Profile()
        {
            // Récupérez l'utilisateur actuel depuis la base de données
            int id = (int)HttpContext.Session.GetInt32("Id");
            var user = db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            // Convertir l'utilisateur en ViewModel pour l'affichage
            var vm = new UserVM
            {
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email,
                CIN = user.CIN,
                Telephone = user.Telephone,
                Role = user.UserType,
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Profile(UserVM vm)
        {
            if (ModelState.IsValid)
            {
                // Récupérez l'utilisateur depuis la base de données
                var userEmail = HttpContext.Session.GetString("Email");
                var user = db.Users.FirstOrDefault(u => u.Email == userEmail);

                if (user != null)
                {
                    // Mettre à jour les informations du profil
                    user.Nom = vm.Nom;
                    user.Prenom = vm.Prenom;
                    user.Email = vm.Email;
                    user.CIN = vm.CIN;
                    user.Telephone = vm.Telephone;
                    user.UserType = vm.Role;

                    db.SaveChanges();

                    // Mettre à jour les valeurs de session si nécessaire
                    HttpContext.Session.SetString("Nom", user.Nom);
                    HttpContext.Session.SetString("Prenom", user.Prenom);
                    HttpContext.Session.SetString("Email", user.Email);

                    // Redirigez vers une page de confirmation ou affichez un message de succès
                    return RedirectToAction("Profile", "Users");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(vm);
        }
    }
}