using Domain.Models.Animal;

namespace Domain.Models.Dogs
{
    public class Dog : AnimalModel
    {
        public string Bark()
        {
            return "This animal barks";
        }
    }
}
