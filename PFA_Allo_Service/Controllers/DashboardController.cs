using Microsoft.AspNetCore.Mvc;
using PFA_Allo_Service.Models;
using PFA_Allo_Service.ViewModel;

namespace PFA_Allo_Service.Controllers
{
    public class DashboardController : Controller
    {
        MyContext db;

        public DashboardController(MyContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                NombreClients = db.Clients.Count(),
                NombreFournisseurs = db.Fournisseurs.Count(),
                NombreServices = db.Services.Count(),
                NombreMetiers = db.Metiers.Count(),
                NombreAdministrateurs = db.Users.Count(u => u.UserType == "Administrateur")
            };

            return View(model);
        }
    }
}
