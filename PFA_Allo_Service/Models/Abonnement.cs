using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class Abonnement
    {
        public int AbonnementId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Fin { get; set; }
        public string Type_Abonnement { get; set; }
        public IList<Fournisseur>?  Fournisseurs { get; set; }
        public Paiement Paiement { get; set; }
    }
}
