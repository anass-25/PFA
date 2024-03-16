namespace  TemplatePFA.Models
{
    public class Abonnement
    {
        public int Id { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public IList<Fournisseur> fournisseurs { get; set; }
        public Paiement paiement { get; set; }
    }
}
