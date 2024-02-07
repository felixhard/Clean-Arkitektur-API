using Domain.Models.AnimalUsers;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Animals
{
    public class Animal
    {
        [Key]
        public Guid AnimalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<AnimalUser>? AnimalUsers { get; set; }
    }
}