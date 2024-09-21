using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.ViewModel
{
    public class ReclamationVm
    {
        //public int ReclamationId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
