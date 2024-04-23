using PFA_Allo_Service.Models;
using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
	public class ServiceVM
	{
		[Required(ErrorMessage = "le libelle est obligatoire")]
		public string Libelle { get; set; }
		public string Description { get; set; }
		[Required(ErrorMessage = "la photo de service est obligatoire")]
		public string Photo { get; set; }
		//public IList<Client_Service>? Clients_Service { get; set; }
	}
}
