using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class InscriptionVM
    {
        [Required(ErrorMessage = "Le champ Nom est requis.")]
        [StringLength(50, ErrorMessage = "Le champ Nom ne peut pas dépasser 50 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est requis.")]
        [StringLength(50, ErrorMessage = "Le champ Prénom ne peut pas dépasser 50 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ CIN est requis.")]
        [RegularExpression("[0-9]{5,6}", ErrorMessage = "vous devez respecter la format de CIN.")]
        public int CIN { get; set; }

        [Required(ErrorMessage = "Le champ Téléphone est requis.")]
        //[RegularExpression("[0-9]{10}", ErrorMessage = "Le champ Téléphone doit être un nombre à 10 chiffres.")]
        public int Telephone { get; set; }

        [Required(ErrorMessage = "Le champ Email est requis.")]
        [EmailAddress(ErrorMessage = "Le champ Email n'est pas une adresse email valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ Rôle est requis.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Le champ Mot de Passe est requis.")]
        [DataType(DataType.Password)]
        public string Mot_de_Passe { get; set; }

        [Compare("Mot_de_Passe", ErrorMessage = "Le champ Confirmation Mot de Passe doit correspondre au Mot de Passe.")]
        [DataType(DataType.Password)]
        public string Confirm_MDP { get; set; }

        public string Localiation { get; set; }
        public bool Disponibilite { get; set; }

    }
}
