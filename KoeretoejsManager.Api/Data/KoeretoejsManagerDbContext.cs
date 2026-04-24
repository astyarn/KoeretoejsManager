using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace KoeretoejsManager.Api.Data
{
    public class KoeretoejsManagerDbContext : DbContext
    {
        public KoeretoejsManagerDbContext(DbContextOptions<KoeretoejsManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DrivingLicense> DrivingLicenses { get; set; }
        public DbSet<UserDrivingLicense> UserDrivingLicenses { get; set; }
        //public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*connecting vehicles with bookings*/
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Vehicle)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);     //Prevents cascade delete of bookings when a vehicle is deleted

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);     //Prevents cascade delete of bookings when a user is deleted


            /*Enum to string for vehicle class*/
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.RequiredLicense)
                .HasConversion<string>();

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Status)
                .HasConversion<string>();


            /*Creation of DrivingLicense entities from DrivingLicenseType enum */
            modelBuilder.Entity<DrivingLicense>()
                .Property(l => l.Type)
                .HasConversion<string>();

            var licenseTypes = Enum.GetValues(typeof(DrivingLicenseType))
                .Cast<DrivingLicenseType>()
                .Select((type, index) => new DrivingLicense
                {
                    DrivingLicenseId = index + 1,
                    Type = type
                });

            modelBuilder.Entity<DrivingLicense>().HasData(licenseTypes);

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

            modelBuilder.Entity<User>()
                .Property(u => u.UserRole)
                .HasConversion<string>();
        }
    }
}
