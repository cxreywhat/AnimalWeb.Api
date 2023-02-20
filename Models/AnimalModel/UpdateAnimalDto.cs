namespace AnimalWeb.Api.Models.AnimalModel
{
    public class UpdateAnimalDto : BaseAnimalDto, IBaseDto
    {
        public int Id { get; set; }
        public string LifeStatus { get; set; }
    }
}