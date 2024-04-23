using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Allo_Service.Models
{
    public class Administrateur : User
    {
        //[Key]
        //public int Id { get; set; }
        public string Role { get; set; }
        public IList<Notification>? Notifications { get; set; }
        public IList<Reclamation>? Reclamations { get; set; }
    }
}
