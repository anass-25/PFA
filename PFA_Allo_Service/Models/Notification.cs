using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Notif { get; set; }
        public string Contenu { get; set; }
        public string Titre { get; set; }
        public Administrateur Administrateur { get; set; }
        public int  AdministrateurId { get; set; }
    }
    //public void Add()
    //{
        
    //}
}