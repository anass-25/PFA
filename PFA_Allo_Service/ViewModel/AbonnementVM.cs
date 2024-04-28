using PFA_Allo_Service.Models;
using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class AbonnementVM
    {
        [Required(ErrorMessage = "la Date debut est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }
        public string Type_Abonnement { get; set; }
    }
}
