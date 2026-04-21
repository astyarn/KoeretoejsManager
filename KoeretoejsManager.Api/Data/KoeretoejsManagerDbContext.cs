using Microsoft.EntityFrameworkCore;

namespace KoeretoejsManager.Api.Data
{
    public class KoeretoejsManagerDbContext : DbContext
    {
        public KoeretoejsManagerDbContext(DbContextOptions<KoeretoejsManagerDbContext> options) : base(options)
        {
            
        }

        //public DbSet<Todo> Todos { get; set; }
    }
}
