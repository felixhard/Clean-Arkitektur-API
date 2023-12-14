using Domain.Models;
using Domain.Models.Dogs;
using Domain.Models.Cats;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedCats(modelBuilder);
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

        private static void SeedCats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "Charlie", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Niklas", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Johan", LikesToPlay = true },
            new Cat { Id = new Guid("00045678-1234-5678-1234-567812345671"), Name = "TestCatForUnitTests1", LikesToPlay = true },
            new Cat { Id = new Guid("00045678-1234-5678-1234-567812345672"), Name = "TestCatForUnitTests2", LikesToPlay = true },
            new Cat { Id = new Guid("00045678-1234-5678-1234-567812345673"), Name = "TestCatForUnitTests3", LikesToPlay = true },
            new Cat { Id = new Guid("01223456-1234-5678-1234-567812345674"), Name = "TestCatForUnitTests4", LikesToPlay = true }
            );
        }
    }
}