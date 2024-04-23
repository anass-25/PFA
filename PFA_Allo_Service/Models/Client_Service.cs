using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class Client_Service
    {
        [Key]
        public int Client_ServiceId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
    }
}
