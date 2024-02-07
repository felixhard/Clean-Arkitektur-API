using Domain.Models.Animals;
using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.AnimalUsers
{
    public class AnimalUser
    {
        [Key]
        public Guid Key { get; set; }
        public required Guid UserId { get; set; }
        public User? User { get; set; }
        public required Guid AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}