﻿namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //public List<UserAnimalModel> UserAnimals { get; set; } = new List<UserAnimalModel>();
    }
}
