namespace Application.Dtos
{
    public class CatDto
    {
        public string Name { get; set; } = string.Empty;


        public string Breed { get; set; } = string.Empty;

        public bool LikesToPlay { get; set; }

        public int Weight { get; set; } = 0;

    }
}