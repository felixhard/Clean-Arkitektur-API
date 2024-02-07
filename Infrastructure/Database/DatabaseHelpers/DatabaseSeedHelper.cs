using Domain.Models;
using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Birds;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Domain.Models.Users;
using Domain.Models.AnimalUsers;
using Domain.Models.Animals.Dogs;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedUsers(modelBuilder);
            SeedBirds(modelBuilder);
            SeedCats(modelBuilder);
            // Add more methods for other entities as needed
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { AnimalId = Guid.NewGuid(), Name = "OldG", Weight = 10, Breed = "Labrador" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "NewG", Weight = 4, Breed = "Bulldog" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Björn", Weight = 12, Breed = "Schäfer" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Patrik", Weight = 13, Breed = "Golden retriever" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Alfred", Weight = 6, Breed = "Pudel" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Stanley", Weight = 6, Breed = "Labrador" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Rufus", Weight = 8, Breed = "Rottweiler" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Ludde", Weight = 9, Breed = "Boxer" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Felix", Weight = 12, Breed = "Labrador" },
            new Dog { AnimalId = Guid.NewGuid(), Name = "Peppe", Weight = 8, Breed = "Boxer" }
            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Username = "admin", Password = "admin", Authorized = true, Role = "admin" },
                new User { Id = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" }
            );
        }
        private static void SeedCats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(
                new Cat { AnimalId = Guid.NewGuid(), Name = "Jack", LikesToPlay = true, Weight = 3, Breed = "Siames" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Signe", LikesToPlay = false, Weight = 4, Breed = "Ragdoll" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Rose", LikesToPlay = false, Weight = 6, Breed = "Bengal" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Mittens", LikesToPlay = true, Weight = 5, Breed = "Burma" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Fred", LikesToPlay = true, Weight = 4, Breed = "Brittiskt korthår" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Molly", LikesToPlay = false, Weight = 6, Breed = "Ragdoll" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Charlie", LikesToPlay = true, Weight = 3, Breed = "Perser" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Oscar", LikesToPlay = true, Weight = 4, Breed = "Burma" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Tiger", LikesToPlay = false, Weight = 5, Breed = "Perser" },
            new Cat { AnimalId = Guid.NewGuid(), Name = "Simba", LikesToPlay = true, Weight = 6, Breed = "Bengal" }
            );
        }
        private static void SeedBirds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bird>().HasData(
                new Bird { AnimalId = Guid.NewGuid(), Name = "Chip", CanFly = false, Color = "Red" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Paulie", CanFly = true, Color = "Blue" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Polly", CanFly = true, Color = "Orange" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Ace", CanFly = false, Color = "Red" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Apollo", CanFly = false, Color = "Green" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Daffy", CanFly = true, Color = "Green" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Blue", CanFly = true, Color = "Purple" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Skye", CanFly = false, Color = "Yellow" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Jay", CanFly = true, Color = "Purple" },
            new Bird { AnimalId = Guid.NewGuid(), Name = "Maverick", CanFly = true, Color = "Yellow" }
            );
        }

    }
}