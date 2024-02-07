namespace Application.Dtos.AnimalDtos.BirdDto
{
    public class BirdDto : AnimalDto
    {
        public string Color { get; set; } = string.Empty;
        public bool CanFly { get; set; }
    }
}
