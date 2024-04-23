using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Allo_Service.Models
{
    public class Avis
    {
        public int AvisId { get; set; }
        public int Note { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Heures { get; set; }
        public string Commentaire { get; set; }
        public Boolean Show { get; set; }
        public Client Client { get; set; }
        public int  ClientId { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public int  FournisseurId { get; set; }
    }
}
