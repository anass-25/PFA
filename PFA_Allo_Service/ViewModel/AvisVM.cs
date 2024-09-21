using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class AvisVM
    {
        // Annotation pour décrire la propriété Note
        [Range(0, 100, ErrorMessage = "La valeur de Note doit être comprise entre 0 et 100.")]
        public int Note { get; set; }

        // Annotation pour spécifier le type de données de la propriété Date_Heures
        [DataType(DataType.DateTime, ErrorMessage = "La valeur doit être une date et une heure valide.")]
        public DateTime Date_Heures { get; set; }

        // Annotation pour spécifier le type de données de la propriété Commentaire
        [StringLength(1000, ErrorMessage = "Le commentaire ne doit pas dépasser 1000 caractères.")]
        public string Commentaire { get; set; }

        // Annotation pour décrire la propriété Show
        [Display(Name = "Afficher", Description = "Indique si l'élément doit être affiché ou non.")]
        public bool Show { get; set; }

    }
}
