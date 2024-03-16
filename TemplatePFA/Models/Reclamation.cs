namespace TemplatePFA.Models
{
    public class Reclamation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Client client { get; set; }
        public int ? ClientId { get; set; }
        public Fournisseur fournisseur { get; set; }
        public int ? FournisseurId { get; set; }
       public Administrateur administrateur { get; set; }
       public int ? AdministrateurId { get; set; }
    }
}
