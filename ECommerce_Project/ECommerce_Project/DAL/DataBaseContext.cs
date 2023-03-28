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

        // Creación indice para Td Conectext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
