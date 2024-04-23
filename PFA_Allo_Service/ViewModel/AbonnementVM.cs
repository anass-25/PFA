using PFA_Allo_Service.Models;
using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class AbonnementVM
    {
        [Required(ErrorMessage = "la Date debut est obligatoire")]
        [DataType(DataType.DateTime)]
        public DateTime Date_Debut { get; set; }
        [Required(ErrorMessage = "la Date debut est obligatoire")]
        [DataType(DataType.DateTime)]
		public DateTime Date_Fin { get; set; }
		[Required(ErrorMessage = "Le champ Type_Abonnement est requis.")]
        public string Type_Abonnement { get; set; }
    }
}
