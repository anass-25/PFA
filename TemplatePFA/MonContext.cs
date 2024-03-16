using Microsoft.EntityFrameworkCore;
using TemplatePFA.Models;

namespace TemplatePFA
{
    public class MonContext:DbContext
    {
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Administrateur> administrateurs { get; set;}
        public DbSet<Avis> avis { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<Client_Service> client_Services { get; set; }
        public DbSet<Fournisseur> fournisseurs { get; set; }
        public DbSet<Message> message { get; set; }
        public DbSet<Metier> metiers { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Offre> offres { get; set; }
        public DbSet<Paiement> paiements { get; set; }
        public DbSet<Reclamation> reclamations { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Simple_User> simple_Users { get; set; }
        public DbSet<User> user { get; set; }
        public MonContext() : base(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), "Data source=.\\SQLEXPRESS;initial catalog=PFA;integrated security=true").Options)
        {

        }
    }
}
