using System.ComponentModel.DataAnnotations;

namespace TemplatePFA.Models
{
    public abstract class  User
    {
        [Key]
        public int idUser { get; set; }
        protected string Nom;
        protected string Prenom;
        protected int CIN;
        protected int Telephone;
        protected string Email;
        protected string Mot_de_Passe;
    }
}
