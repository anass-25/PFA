using PFA_Allo_Service.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class  User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public int Telephone { get;  set; }
        public string Email { get;  set; }
        public string Mot_de_Passe { get; set; }
        public string UserType { get; set; }
    }
}
