namespace TemplatePFA.Models
{

    public class Administrateur : User
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public IList<Notification> notifications { get; set; }
        public IList<Reclamation> reclamations { get; set; }
    }
}
