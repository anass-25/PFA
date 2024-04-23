using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class Paiement
    {
        public int PaiementId { get; set; }
        public float Montant { get; set; }
        //public string Type_Abonnement { get; set; }
        public string Carte_Paiement { get; set; }
        public Abonnement? Abonnement { get; set; }
        public int? AbonnementId { get; set; }
    }
}
