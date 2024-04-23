using Microsoft.EntityFrameworkCore;
using System;

namespace PFA_Allo_Service.Models
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Simple_User> Simple_Users { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set;}
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Client> Clients { get; set;}
        public DbSet<Service> Services { get; set; }
        public DbSet<Client_Service> Client_Services { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set;}
        public DbSet<Metier> Metiers { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Avis> Avis { get; set;}
        public DbSet<Message> Messages { get; set;}
        public DbSet<Reclamation> Reclamations { get; set;}
        public MyContext(DbContextOptions<MyContext> opt):base(opt) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.ToTable("Users")
				.HasDiscriminator<string>("UserType")
				.HasValue<User>("User")
				.HasValue<Simple_User>("SimpleUser")
				.HasValue<Administrateur>("Administrateur")
				.HasValue<Client>("Client")
				.HasValue<Fournisseur>("Fournisseur");

			modelBuilder.Entity<Avis>()
		.HasOne(a => a.Fournisseur)
		.WithMany(f => f.Avis)
		.HasForeignKey(a => a.FournisseurId)
		.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Avis>()
	  .HasOne(a => a.Client)
	  .WithMany(c => c.Avis)
	  .HasForeignKey(a => a.ClientId)
	  .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Client_Service>()
	   .HasOne(cs => cs.Client)
	   .WithMany(c => c.Client_Services)
	   .HasForeignKey(cs => cs.ClientId)
	   .OnDelete(DeleteBehavior.Cascade); // Permet la suppression en cascade

			modelBuilder.Entity<Client_Service>()
				.HasOne(cs => cs.Service)
				.WithMany(s => s.Clients_Service)
				.HasForeignKey(cs => cs.ServiceId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Message>()
		.HasOne(m => m.Fournisseur)
		.WithMany(f => f.Messages)
		.HasForeignKey(m => m.FournisseurId)
		.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Message>()
	   .HasOne(m => m.Client)
	   .WithMany(c => c.Messages)
	   .HasForeignKey(m => m.ClientId)
	   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Offre>()
		.HasOne(m => m.Fournisseur)
		.WithMany(f => f.Offres)
		.HasForeignKey(m => m.FournisseurId)
		.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Reclamation>()
		.HasOne(m => m.Fournisseur)
		.WithMany(f => f.Reclamations)
		.HasForeignKey(m => m.FournisseurId)
		.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Reclamation>()
		.HasOne(m => m.Client)
		.WithMany(f => f.Reclamations)
		.HasForeignKey(m => m.ClientId)
		.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Reclamation>()
	   .HasOne(r => r.Administrateur)
	   .WithMany(a => a.Reclamations)
	   .HasForeignKey(r => r.AdministrateurId)
	   .OnDelete(DeleteBehavior.Restrict);
		}

	}


	//protected override void OnModelCreating(ModelBuilder modelBuilder)
	//{
	//    base.OnModelCreating(modelBuilder);

	//    modelBuilder.Entity<User>()
	//        .ToTable("users")
	//        .HasDiscriminator<string>("UserType")
	//        .HasValue<Client>("Client")
	//        .HasValue<Fournisseur>("Fournisseur")
	//        .HasValue<Administrateur>("Administrateur");

	//    modelBuilder.Entity<User>().HasKey(u => u.UserId);

	//    // Ajoutez ici les configurations pour les autres entités si nécessaire
	//}
}
