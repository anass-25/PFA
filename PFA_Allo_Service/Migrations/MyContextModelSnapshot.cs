﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PFA_Allo_Service.Models;

#nullable disable

namespace PFA_Allo_Service.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PFA_Allo_Service.Models.Abonnement", b =>
                {
                    b.Property<int>("AbonnementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbonnementId"), 1L, 1);

                    b.Property<DateTime>("Date_Debut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type_Abonnement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbonnementId");

                    b.ToTable("Abonnements");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Avis", b =>
                {
                    b.Property<int>("AvisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvisId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Heures")
                        .HasColumnType("datetime2");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("AvisId");

                    b.HasIndex("ClientId");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Avis");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Client_Service", b =>
                {
                    b.Property<int>("Client_ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Client_ServiceId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Client_ServiceId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Client_Services");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Heures")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("ClientId");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Metier", b =>
                {
                    b.Property<int>("MetierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetierId"), 1L, 1);

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MetierId");

                    b.ToTable("Metiers");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<int>("AdministrateurId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Notif")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.HasIndex("AdministrateurId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Offre", b =>
                {
                    b.Property<int>("OffreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OffreId"), 1L, 1);

                    b.Property<DateTime>("Date_Debut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Fin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prix")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OffreId");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Offres");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Paiement", b =>
                {
                    b.Property<int>("PaiementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaiementId"), 1L, 1);

                    b.Property<int?>("AbonnementId")
                        .HasColumnType("int");

                    b.Property<string>("Carte_Paiement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Montant")
                        .HasColumnType("real");

                    b.HasKey("PaiementId");

                    b.HasIndex("AbonnementId")
                        .IsUnique()
                        .HasFilter("[AbonnementId] IS NOT NULL");

                    b.ToTable("Paiements");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Reclamation", b =>
                {
                    b.Property<int>("ReclamationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReclamationId"), 1L, 1);

                    b.Property<int>("AdministrateurId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.HasKey("ReclamationId");

                    b.HasIndex("AdministrateurId");

                    b.HasIndex("ClientId");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Reclamations");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CIN")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mot_de_Passe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<string>("UserType").HasValue("User");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Administrateur", b =>
                {
                    b.HasBaseType("PFA_Allo_Service.Models.User");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Administrateur");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Simple_User", b =>
                {
                    b.HasBaseType("PFA_Allo_Service.Models.User");

                    b.HasDiscriminator().HasValue("SimpleUser");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Client", b =>
                {
                    b.HasBaseType("PFA_Allo_Service.Models.Simple_User");

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Fournisseur", b =>
                {
                    b.HasBaseType("PFA_Allo_Service.Models.Simple_User");

                    b.Property<int>("AbonnementId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponibiliter")
                        .HasColumnType("bit");

                    b.Property<int>("MetierId")
                        .HasColumnType("int");

                    b.HasIndex("AbonnementId");

                    b.HasIndex("MetierId");

                    b.HasDiscriminator().HasValue("Fournisseur");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Avis", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Client", "Client")
                        .WithMany("Avis")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PFA_Allo_Service.Models.Fournisseur", "Fournisseur")
                        .WithMany("Avis")
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Client_Service", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Client", "Client")
                        .WithMany("Client_Services")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PFA_Allo_Service.Models.Service", "Service")
                        .WithMany("Clients_Service")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Message", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Client", "Client")
                        .WithMany("Messages")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PFA_Allo_Service.Models.Fournisseur", "Fournisseur")
                        .WithMany("Messages")
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Notification", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Administrateur", "Administrateur")
                        .WithMany("Notifications")
                        .HasForeignKey("AdministrateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrateur");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Offre", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Fournisseur", "Fournisseur")
                        .WithMany("Offres")
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Paiement", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Abonnement", "Abonnement")
                        .WithOne("Paiement")
                        .HasForeignKey("PFA_Allo_Service.Models.Paiement", "AbonnementId");

                    b.Navigation("Abonnement");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Reclamation", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Administrateur", "Administrateur")
                        .WithMany("Reclamations")
                        .HasForeignKey("AdministrateurId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PFA_Allo_Service.Models.Client", "Client")
                        .WithMany("Reclamations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PFA_Allo_Service.Models.Fournisseur", "Fournisseur")
                        .WithMany("Reclamations")
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Administrateur");

                    b.Navigation("Client");

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Fournisseur", b =>
                {
                    b.HasOne("PFA_Allo_Service.Models.Abonnement", "Abonnement")
                        .WithMany("Fournisseurs")
                        .HasForeignKey("AbonnementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PFA_Allo_Service.Models.Metier", "metier")
                        .WithMany("Fournisseurs")
                        .HasForeignKey("MetierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abonnement");

                    b.Navigation("metier");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Abonnement", b =>
                {
                    b.Navigation("Fournisseurs");

                    b.Navigation("Paiement")
                        .IsRequired();
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Metier", b =>
                {
                    b.Navigation("Fournisseurs");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Service", b =>
                {
                    b.Navigation("Clients_Service");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Administrateur", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Reclamations");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Client", b =>
                {
                    b.Navigation("Avis");

                    b.Navigation("Client_Services");

                    b.Navigation("Messages");

                    b.Navigation("Reclamations");
                });

            modelBuilder.Entity("PFA_Allo_Service.Models.Fournisseur", b =>
                {
                    b.Navigation("Avis");

                    b.Navigation("Messages");

                    b.Navigation("Offres");

                    b.Navigation("Reclamations");
                });
#pragma warning restore 612, 618
        }
    }
}
