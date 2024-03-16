namespace TemplatePFA.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date_Heures { get; set; }
        public Client  client { get; set; }
        public int ? ClientId  { get; set; }
        public Fournisseur  fournisseur { get; set; }
        public int ? FournisseurId { get; set; }
    }
}