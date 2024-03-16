namespace TemplatePFA.Models
{
    public class Metier
    {
        public int Id { get; set; }
        public string Categorie { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Service { get; set; }
        public IList<Fournisseur> fournisseurs { get; set; }
    }
}
