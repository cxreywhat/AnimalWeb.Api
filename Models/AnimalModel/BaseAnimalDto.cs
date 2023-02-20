namespace AnimalWeb.Api.Models.AnimalModel
{
    public class BaseAnimalDto
    {
        private string Name { get; set; } = string.Empty;
        public string AnimalType { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
    }
}