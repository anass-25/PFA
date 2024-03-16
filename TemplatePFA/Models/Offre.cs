namespace TemplatePFA.Models
{
    public class Offre
    {
        public int Id { get; set; }
        public int Prix { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public string Titre { get; set; }
        public Fournisseur fournisseur { get; set; }
        public int ? FournniseurId { get; set; }
    }
}
