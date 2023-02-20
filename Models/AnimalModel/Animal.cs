namespace AnimalWeb.Api.Models.AnimalModel
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AnimalType { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public DateTime ChipingDateTime { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
        public string LifeStatus { get; set; } = "Alive";
    }
}