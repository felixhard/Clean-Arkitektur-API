using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Animals.Birds
{
    public class Bird : Animal
    {

        public bool CanFly { get; set; }
        public required string Color { get; set; }


    }
}