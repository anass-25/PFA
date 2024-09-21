using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Email == email && u.Mot_de_Passe == password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Nom", user.Nom);
                    HttpContext.Session.SetString("Prenom", user.Prenom);
                    HttpContext.Session.SetString("Role", user.UserType);

                    if (user.UserType == "Fournisseur")
                    {
                        // Redirect to Fournisseur controller's Index action
                        int id = user.Id;
                        var fournisseur = db.Fournisseurs.FirstOrDefault(f => f.Id == id);
                        if (fournisseur.Photo != null) 
                        {
                            HttpContext.Session.SetString("Photo", fournisseur.Photo);
                        }
                        else
                        {
                            HttpContext.Session.SetString("Photo", "img.jpg");
                        }
                        return RedirectToAction("Index", "Fournisseur");
                    }
                    else if (user.UserType == "Client")
                    {
                        // Redirect to Client controller's Index action
                        return RedirectToAction("Index", "Client");
                    }
                    else
                    {
                        // Redirect to Admin controller's Index action
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
            ViewBag.MetierList = new SelectList(db.Metiers, "MetierId", "Categorie");
            return View();
        }
        [HttpPost]
        public IActionResult UsersInscription(InscriptionVM vm)
        {
            ViewBag.MetierList =  new SelectList(db.Metiers, "MetierId", "Categorie");
            if (ModelState.IsValid)
            {
                // verifier que le login(email) est unique
                int count = db.Users.Where(us => us.Email == vm.Email).Count();
                if (count == 0)
                {
					User user;
					if (vm.Role == "Client")
					{
						user = new Client
						{
							Nom = vm.Nom,
							Prenom = vm.Prenom,
							CIN = vm.CIN,
							Telephone = vm.Telephone,
							Email = vm.Email,
							Mot_de_Passe = vm.Mot_de_Passe,
							Localisation = vm.Localisation,
							UserType = vm.Role
						};
					}
					else if (vm.Role == "Fournisseur")
					{
						user = new Fournisseur
						{
							Nom = vm.Nom,
							Prenom = vm.Prenom,
							CIN = vm.CIN,
							Telephone = vm.Telephone,
							Email = vm.Email,
							Mot_de_Passe = vm.Mot_de_Passe,
							Disponibiliter = vm.Disponibiliter,
							UserType = vm.Role,
                            MetierId = vm.MetierId
                        };
					}
					else
					{
						// Handle error: invalid role
						ModelState.AddModelError("Role", "Invalid role selected.");
						return View(vm);
					}
					db.Users.Add(user);
                    db.SaveChanges();
                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("Nom", user.Nom);
                    HttpContext.Session.SetString("Prenom", user.Prenom);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Role", user.UserType);
                    return RedirectToAction(nameof(Login)); // Produit za3ma mnin  nsaliw inscription yadini l had class Produit ri example 
                }
                ModelState.AddModelError("Email", "Email existe deja "); // anotation pour email deja existe il s'appelle annotation unique



            }
            return View();
        }
        public IActionResult modifierProfils()
        {
            // Récupérez l'utilisateur actuel depuis la base de données
            int id = (int)HttpContext.Session.GetInt32("Id");
            var user = db.Users.FirstOrDefault(u => u.Id == id);



            //Les information de fornisseur .
            // var fornisseur = db.Fournisseurs.ToList();
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.UserType = user.UserType;
            // Convertir l'utilisateur en ViewModel pour l'affichage
            var vm = new modifierProfilsVm();
            {
                vm.Nom = user.Nom;
                vm.Prenom = user.Prenom;
                vm.Email = user.Email;
                vm.CIN = user.CIN;
                vm.Telephone = user.Telephone;


                //code ajouter
                if (user.UserType == "Fournisseur")
                {
                    var fournisseur = db.Fournisseurs.ToList().FirstOrDefault(f => f.Id == id);
                    if (fournisseur != null)
                    {
                        //vm.Photo = fournisseur.Photo;
                        //vm.Photo = "data:image/png;base64," + Convert.ToBase64String(fournisseur.Photo);
                        //var photo = vm.Photo;
                        string photos = fournisseur.Photo;
                        vm.photos = photos;
                    }

                    // Autres propriétés...
                };
                return View(vm);
            }

        }
        [HttpPost]
        public IActionResult modifierProfils([FromForm] modifierProfilsVm o)
        {
            // Récupérez l'utilisateur actuel depuis la base de données
            int id = (int)HttpContext.Session.GetInt32("Id");
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    // Mettre à jour les informations du profil
                    user.Nom = o.Nom;
                    user.Prenom = o.Prenom;
                    user.Email = o.Email;
                    user.CIN = o.CIN;
                    user.Telephone = o.Telephone;
                    db.SaveChanges();

                    if (user.UserType == "Fournisseur")
                    {
                        var fournisseur = db.Fournisseurs.FirstOrDefault(f => f.Id == id);
                        if (fournisseur != null)
                        {
                            if (o.Photo != null && o.Photo.Length > 0)
                            {
                                string[] allowedExtensions = { ".jpg", ".png", ".jpeg", ".svg", ".webp", ".gif" };
                                string fileExt = Path.GetExtension(o.Photo.FileName).ToLower();
                                if (allowedExtensions.Contains(fileExt))
                                {
                                    string uniqueFileName = $"{DateTime.Now.Ticks}_{Guid.NewGuid().ToString().Substring(0, 4)}{fileExt}";
                                    string pathFile = Path.Combine("wwwroot/images", uniqueFileName);

                                    if (!string.IsNullOrEmpty(fournisseur.Photo))
                                    {
                                        string oldFilePath = Path.Combine("wwwroot/images", fournisseur.Photo);
                                        if (System.IO.File.Exists(oldFilePath))
                                        {
                                            System.IO.File.Delete(oldFilePath);
                                        }
                                    }
                                    using (var stream = new FileStream(pathFile, FileMode.Create))
                                    {
                                        o.Photo.CopyTo(stream);
                                    }
                                    fournisseur.Photo = uniqueFileName;
                                    db.SaveChanges();
                                }
                                HttpContext.Session.SetString("Photo", fournisseur.Photo);
                            }
                        }
                    }

                    // Mettre à jour les valeurs de session si nécessaire
                    HttpContext.Session.SetString("Nom", user.Nom);
                    HttpContext.Session.SetString("Prenom", user.Prenom);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("CIN", user.CIN.ToString());
                    HttpContext.Session.SetString("Telephone", user.Telephone.ToString());

                    // Redirection conditionnelle en fonction du type d'utilisateur
                    if (user.UserType == "Fournisseur")
                    {
                        return RedirectToAction("Index", "Fournisseur");
                    }
                    else if (user.UserType == "Client")
                    {
                        return RedirectToAction("Index", "Accueil");
                    }
                }
            }
            return View(o);
        }

        //code de Anas 
        public IActionResult ChangePassword()
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            if (userId == null)
            {
                return NotFound();
            }

            var user = db.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            // Stockez le type d'utilisateur dans ViewData pour le passer à la vue
            ViewData["UserType"] = user.UserType;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                int id = (int)HttpContext.Session.GetInt32("Id");
                model.UserId = id;
                if (model.UserId != null)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == model.UserId);
                    if (user != null)
                    {
                        if (user.Mot_de_Passe == model.CurrentPassword)
                        {
                            if (model.NewPassword == model.ConfirmPassword)
                            {
                                user.Mot_de_Passe = model.NewPassword;
                                db.Update(user);
                                db.SaveChanges();
                                if (user.UserType == "Fournisseur")
                                {
                                    return RedirectToAction("Index", "Fournisseur");
                                }
                                else
                                {
                                    return RedirectToAction("Index", "Accueil");
                                }
                                
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, "Le nouveau mot de passe et la confirmation ne correspondent pas.");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Le mot de passe actuel est incorrect.");
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Users");
        }
    }
}