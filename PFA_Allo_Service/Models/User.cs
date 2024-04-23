using PFA_Allo_Service.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace PFA_Allo_Service.Models
{
    public class  User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int CIN { get; set; }
        public int Telephone { get;  set; }
        public string Email { get;  set; }
        public string Mot_de_Passe { get; set; }
        public string UserType { get; set; }

    //    protected bool IsValidType(string type)
    //    {
    //        return type == "Administrateur" || type == "Client" || type == "Fournisseur";
    //    }

    //    // Méthode pour définir le type
    //    public void SetType(string type)
    //    {
    //        if (IsValidType(type))
    //        {
				//UserType = type;
    //        }
    //        else
    //        {
    //            throw new ArgumentException("Type invalide.");
    //        }
    //    }
    }
}
