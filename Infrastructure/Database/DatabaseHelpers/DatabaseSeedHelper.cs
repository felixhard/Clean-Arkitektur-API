using Domain.Models;
using Domain.Models.Dogs;
using Domain.Models.Cats;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Domain.Models.Users;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedUsers(modelBuilder);
            // Add more methods for other entities as needed
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { Id = Guid.NewGuid(), Name = "Björn" },
                new Dog { Id = Guid.NewGuid(), Name = "Patrik" },
                new Dog { Id = Guid.NewGuid(), Name = "Alfred" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345671"), Name = "TestDogForUnitTests1" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345672"), Name = "TestDogForUnitTests2" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345673"), Name = "TestDogForUnitTests3" },
                new Dog { Id = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDogForUnitTests4" }
            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Username = "admin", Password = "admin", Authorized = true, Role = "admin" },
                new User { Id = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" }
            );
        }
    }
}