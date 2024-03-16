namespace TemplatePFA.Models
{
    public class Fournisseur : Simple_User
    {
        public int Id { get; set; } 
        public Boolean Disponibiliter { get; set; }
        public string Abonnement { get; set; }
        public Metier metier { get; set; }
        public int ? MetierId { get; set; }
        public IList<Offre> offres { get; set; }
        public Abonnement abonnement { get; set; }
        public int ? AbonnementId { get; set; }
        public IList<Avis> avis { get; set; }
        public IList<Message> messages { get; set; }
        public IList<Reclamation> reclamations { get; set; }
    }
}