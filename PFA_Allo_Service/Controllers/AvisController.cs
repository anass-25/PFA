using Microsoft.AspNetCore.Mvc;
using PFA_Allo_Service.Models;

namespace PFA_Allo_Service.Controllers
{
    public class AvisController : Controller
    {
        MyContext db;
        public AvisController(MyContext db)     //constructeur de MyControlleur,  c est injectiion de depondance , traivaille  de my conr=texte sans instancier pour eviter coplage fort
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Avis> avies = db.Avis.ToList();
            // List<AvisVM> avies = db.Avies.Select(p => new AvisVM(p)).ToList();
            return View(avies);
        }
    }
}
