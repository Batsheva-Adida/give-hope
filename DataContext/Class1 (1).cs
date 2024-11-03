using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interface;

namespace DataContext
{
    public class Db : DbContext, IContext
    {
        public DbSet<Categories> categories { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Medicines> medicines { get; set; }
        public DbSet<Question> question { get; set; }   
        public DbSet<Comments> comments { get; set; }

        public async Task save()
        {
            await SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BAT-SHEVA;database=master14;TrustServerCertificate=true;trusted_connection=true");

        }
    }
}