namespace PFA_Allo_Service.Models
{
    public class Metier
    {
        public int MetierId { get; set; }
        public string Categorie { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Service { get; set; }
        public IList<Fournisseur>? Fournisseurs { get; set; }
    }
}
