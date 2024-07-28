using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
namespace BookManagementSys.Models.Domain
    
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {

        }
        public DbSet<Genere> Generes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Auther> Authers { get; set; }

    }
}
