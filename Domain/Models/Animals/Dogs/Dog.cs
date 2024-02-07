using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Models.Animals.Dogs
{
    public class Dog : Animal
    {
        public required string Breed { get; set; }
        public int Weight { get; set; }
        public string Bark()
        {
            return "This animal barks";
        }

    }
}
