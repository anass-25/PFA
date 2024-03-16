namespace TemplatePFA.Models
{
    public class Client : Simple_User
    {
        public int Id { get; set; }
        public string Localisation { get; set; }
        public IList<Reclamation> reclamations { get; set; }
        public IList<Client_Service> client_Services { get; set; }
        public IList<Message>  messages { get; set; }
        public IList<Avis> avis { get; set; }
    }
}
