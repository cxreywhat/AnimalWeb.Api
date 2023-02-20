namespace AnimalWeb.Api.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Animal, CreateAnimalDto>().ReverseMap();
            CreateMap<Animal, UpdateAnimalDto>().ReverseMap();
        }
    }
}