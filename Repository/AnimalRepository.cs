namespace AnimalWeb.Api.Repository
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(DataContext context, IMapper mapper) :
            base(context, mapper) { }
    }
}