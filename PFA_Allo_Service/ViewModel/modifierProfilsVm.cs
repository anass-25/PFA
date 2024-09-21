using PFA_Allo_Service.Models;
using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class modifierProfilsVm
    {
        [Required(ErrorMessage = "Le champ Nom est requis.")]
        [StringLength(50, ErrorMessage = "Le champ Nom ne peut pas dépasser 50 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est requis.")]
        [StringLength(50, ErrorMessage = "Le champ Prénom ne peut pas dépasser 50 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Email est requis.")]
        [EmailAddress(ErrorMessage = "Le champ Email n'est pas une adresse email valide.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Oubliger de ecrir votre Nemuro")]
        public int Telephone { get; set; }

        [Required(ErrorMessage = "Oubliger de saisir Votre Carte Identite ")]
        public string CIN { get; set; }

        //public string ? Photo {  get; set; }
        public IFormFile? Photo { get; set; }
        public string? photos { get; set; }
		public Metier? metier { get; set; }
		public int? MetierId { get; set; }
	}
}
