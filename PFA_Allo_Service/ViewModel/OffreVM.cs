using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
	public class OffreVM
	{
		[Required(ErrorMessage = "Le champ Prix est requis.")]
		public int Prix { get; set; }

		[Required(ErrorMessage = "Le champ Photo est requis.")]
		public string Photo { get; set; }

		[Required(ErrorMessage = "Le champ Description est requis.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Le champ Date de Début est requis.")]
		public DateTime Date_Debut { get; set; }

		[Required(ErrorMessage = "Le champ Date de Fin est requis.")]
		public DateTime Date_Fin { get; set; }

		[Required(ErrorMessage = "Le champ Titre est requis.")]
		public string Titre { get; set; }
	}
}
