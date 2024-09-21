using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
	public class Metier
	{
		public int MetierId { get; set; }
		public string Categorie { get; set; }
		public string Description { get; set; }
		// Autres propriétés
		[Required(ErrorMessage = "Le champ Photo est requis.")]
		public string Photo { get; set; }
		public Service? service { get; set; }
		public int? ServiceId { get; set; }
		public IList<Fournisseur>? Fournisseurs { get; set; }
	}
}