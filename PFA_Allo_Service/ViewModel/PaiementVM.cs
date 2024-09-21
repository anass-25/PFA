using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class PaiementVM
    {
        [Display(Name = "Abonnement")]
        [Required(ErrorMessage = "L'abonnement est requis.")]
        public int AbonnementId { get; set; }
        [Required(ErrorMessage = "Le montant est requis.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à zéro.")]
        public float Montant { get; set; }
    }
}
