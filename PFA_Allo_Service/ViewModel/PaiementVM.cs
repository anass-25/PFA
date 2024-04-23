using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class PaiementVM
    {
        public float Montant { get; set; }
        //[Required(ErrorMessage = "Le type d'abonnement est requis.")]
        //public string Type_Abonnement { get; set; }
        [Required(ErrorMessage = "Le numéro de carte de paiement est requis.")]
        //[RegularExpression(@"^\d{16}$", ErrorMessage = "Le numéro de carte de paiement doit contenir exactement 16 chiffres.")]

         [Display(Name = "Abonnement")]
        public int AbonnementId { get; set; }
        public string Carte_Paiement { get; set; }
    }
}
