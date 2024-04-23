using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Allo_Service.Models
{
    public class Fournisseur : Simple_User
    {
        //[Key]
        //public int Id { get; set; } 
        public bool Disponibiliter { get; set; }
        //public string abonnement { get; set; }
        public Metier metier { get; set; }
        public int MetierId { get; set; }
        public IList<Offre>? Offres { get; set; }
        public Abonnement Abonnement { get; set; }
        public int AbonnementId { get; set; }
        public IList<Avis>? Avis { get; set; }
        public IList<Message>? Messages { get; set; }
        public IList<Reclamation>? Reclamations { get; set; }
    }
}