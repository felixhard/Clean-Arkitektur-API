namespace Application.Dtos.AnimalDtos.CatDto
{
    public class CatDto : AnimalDto
    {
        public bool LikesToPlay { get; set; }
        public string Breed { get; set; } = string.Empty;
        public int Weight { get; set; }
    }
}
