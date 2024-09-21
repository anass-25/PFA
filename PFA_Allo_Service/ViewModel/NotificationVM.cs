using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class NotificationVM
    {
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Contenu { get; set; }
        public string UserType { get; set; }
    }
}
