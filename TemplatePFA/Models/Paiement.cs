namespace TemplatePFA.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public float Montant { get; set; }
        public string Type_Abonnement { get; set; }
        public string Carte_Paiement { get; set; }
        public Abonnement abonnement { get; set; }
        public int ? AbonnementId { get; set; }
    }
}
