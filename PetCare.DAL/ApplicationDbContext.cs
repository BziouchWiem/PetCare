using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PetCare.Models;

namespace PetCare.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PetCareDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Animal> Animaux { get; set; }
        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Veterinaire> Veterinaires { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<TypeAnimal> TypesAnimaux { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Ajoute ici si besoin des configurations personnalisées
        }
    }
}


