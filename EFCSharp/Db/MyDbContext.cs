using EFCSharp.Models;
using Microsoft.EntityFrameworkCore;
namespace EFCSharp.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<Musica> musica { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=127.0.0.1;User Id=root; Password=vertrigo; Database=musica";
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