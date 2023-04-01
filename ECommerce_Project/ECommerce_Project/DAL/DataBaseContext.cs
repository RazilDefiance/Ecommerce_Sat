using ECommerce_Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Project.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        // Mapeando identidad
        public DbSet<Country> Countries { get; set; } // Creación de tablas
        public DbSet<Category> Categories { get; set; } // Creación de tablas

        // Creación indice para las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
