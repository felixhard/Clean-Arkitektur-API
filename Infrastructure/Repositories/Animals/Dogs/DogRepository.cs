﻿using Domain.Models;
using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Dogs;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Animals.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly RealDatabase _realDatabase;

        public DogRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Dog> AddDog(Dog newDog)
        {
            try
            {
                _realDatabase.Dogs.Add(newDog);
                _realDatabase.SaveChanges();
                return await Task.FromResult(newDog);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Dog> DeleteDog(Guid id)
        {
            try
            {
                Dog dogToDelete = await GetDogById(id);

                _realDatabase.Dogs.Remove(dogToDelete);

                _realDatabase.SaveChanges();

                return await Task.FromResult(dogToDelete);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while deleting a dog with Id {id} from the database", ex);
            }
        }

        public async Task<List<Dog>> GetAllDogs()
        {
            try
            {
                return await _realDatabase.Dogs.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occured while getting all dogs from the database", ex);
            }
        }

        public async Task<Dog> GetDogById(Guid id)
        {
            try
            {
                Dog? wantedDog = await _realDatabase.Dogs.FirstOrDefaultAsync(dog => dog.AnimalId == id);

                if (wantedDog == null)
                {
                    throw new Exception($"There was no dog with Id {id} in the database");
                }

                return await Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while getting a dog with Id {id} from database", ex);
            }
        }

        public async Task<List<Dog>> GetDogsByBreedAndWeight(string breed, int? weight)
        {
            var dogsQuery = _realDatabase.Dogs.AsQueryable();

            if (!string.IsNullOrEmpty(breed))
            {
                dogsQuery = dogsQuery.Where(dog => dog.Breed == breed);
            }

            if (weight.HasValue)
            {
                dogsQuery = dogsQuery.Where(dog => dog.Weight == weight);
            }

            return await dogsQuery.ToListAsync();
        }


        public Task<Dog> UpdateDog(Dog updateDog)
        {
            try
            {
                _realDatabase.Dogs.Update(updateDog);

                _realDatabase.SaveChanges();

                return Task.FromResult(updateDog);
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occured while updating a dog by Id {updateDog.AnimalId} from database", ex);
            }
        }
    }
}