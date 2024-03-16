namespace TemplatePFA.Models
{
    public class Avis
    {
        public int Id { get; set; }
        public int Note { get; set; }
        public DateTime Date_Heures { get; set; }
        public string Commentaire { get; set; }
        public Boolean Show { get; set; }
        public Client client { get; set; }
        public int ? Client { get; set; }
        public Fournisseur fournisseur { get; set; }
        public int ? FournisseurId { get; set; }
    }
}
