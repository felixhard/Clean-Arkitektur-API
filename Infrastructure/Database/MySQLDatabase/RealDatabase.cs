using Domain.Models.Animals;
using Domain.Models.Animals.Dogs;
using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Birds;
using Domain.Models.AnimalUsers;
using Domain.Models.Users;
using Infrastructure.Database.DatabaseHelpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.MySQLDatabase
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalUser> AnimalUsers { get; set; }

        // Do not really know why I have to keep this safe guard here but hell... Let it be until we find out why...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Byt Connectionstring här med så det passar lokalt
            optionsBuilder.UseSqlServer("Server=TAURUS\\SQLEXPRESS;Database=TestingDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
