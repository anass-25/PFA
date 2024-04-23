using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class Offre
    {
        public int OffreId { get; set; }
        public int Prix { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Fin { get; set; }
        public string Titre { get; set; }
        public Fournisseur? Fournisseur { get; set; }
        public int?  FournisseurId { get; set; }
    }
}
