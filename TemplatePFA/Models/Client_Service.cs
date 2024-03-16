namespace TemplatePFA.Models
{
    public class Client_Service
    {
        public int Id { get; set; }
        public Client client { get; set; }
        public int ClientId { get; set; }
        public Service service { get; set; }
        public int ServiceId { get; set; }
    }
}
