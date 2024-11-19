using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Saladesport.Models;

namespace Saladesport.Models
{
    public class SaladesportContext : DbContext
    {
        public SaladesportContext(DbContextOptions<SaladesportContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();

        }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Abonament> Abonaments { get; set; }
        public DbSet<Visitator> Visitators { get; set; }
        public DbSet<Snacks> Snackses { get; set; }
        public DbSet<Filiale> Filiales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<Abonament>().ToTable("Abonament");
            modelBuilder.Entity<Filiale>().ToTable("Filiale");
            modelBuilder.Entity<Visitator>().ToTable("Visitator");
            modelBuilder.Entity<Snacks>().ToTable("Snacks");
        }
        public DbSet<Saladesport.Models.Filiale> Filiale { get; set; } = default!;
        public DbSet<Saladesport.Models.Snacks> Snacks { get; set; } = default!;
        public DbSet<Saladesport.Models.Visitator> Visitator { get; set; } = default!;
    }
}
