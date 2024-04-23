using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Allo_Service.Models
{
    public class Client : Simple_User
    {
        //[Key]
        //public int Id { get; set; }
        public string Localisation { get; set; }
        public IList<Reclamation>? Reclamations { get; set; }
        public IList<Client_Service>? Client_Services { get; set; }
        public IList<Message>?  Messages { get; set; }
        public IList<Avis>? Avis { get; set; }
    }
}
