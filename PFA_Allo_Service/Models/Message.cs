using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Heures { get; set; }
        public Client  Client { get; set; }
        public int  ClientId  { get; set; }
        public Fournisseur  Fournisseur { get; set; }
        public int  FournisseurId { get; set; }
    }
}