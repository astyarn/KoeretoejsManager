using KoeretoejsManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KoeretoejsManager.Api.Data
{
    public class KoeretoejsManagerDbContext : DbContext
    {
        public KoeretoejsManagerDbContext(DbContextOptions<KoeretoejsManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DrivingLicense> DrivingLicenses { get; set; }
        public DbSet<UserDrivingLicense> UserDrivingLicenses { get; set; }
        //public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*Many to Many relation between User and DrivingLicense*/
            modelBuilder.Entity<UserDrivingLicense>()
                .HasKey(x => new { x.UserId, x.DrivingLicenseId });

            modelBuilder.Entity<UserDrivingLicense>()
                .HasOne(x => x.User)
                .WithMany(u => u.UserDrivingLicense)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserDrivingLicense>()
                .HasOne(x => x.DrivingLicense)
                .WithMany(l => l.UserDrivingLicense)
                .HasForeignKey(x => x.DrivingLicenseId);
        }
    }
}
