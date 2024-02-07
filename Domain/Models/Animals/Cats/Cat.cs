using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Models.Animals.Cats
{
    public class Cat : Animal
    {
        public bool LikesToPlay { get; set; }
        public required string Breed { get; set; }
        public int Weight { get; set; }

    }

}
