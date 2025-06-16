using EFCSharpCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCSharpCliente.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<Cliente> cliente { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
           "Server=127.0.0.1;User Id=root; Password=vertrigo; Database=cliente";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString,
               ServerVersion.AutoDetect(connectionString));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}