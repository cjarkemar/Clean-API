namespace Application.Dtos
{
    public class CatDto
    {
        public string Name { get; set; } = string.Empty;
        public bool LikesToPlay { get; set; }

        public string Breed { get; set; } = string.Empty;

        public int Weight { get; set; } = 0;

    }
}