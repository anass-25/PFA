namespace TemplatePFA.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Date_Notif { get; set; }
        public string Contenu { get; set; }
        public string Titre { get; set; }
        public Administrateur administrateur { get; set; }
        public int ? AdministrateurId { get; set; }
    }
}