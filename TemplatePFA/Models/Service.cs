//using System.Security.Policy;

namespace TemplatePFA.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Libelle { get; set; } 
        public string Description { get; set; }
        public string Photo { get; set; }
        public IList<Client_Service> Clients_Service { get; set; }
    }
}
