using IntegrationTestLab.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTestLab.Infra
{


    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
