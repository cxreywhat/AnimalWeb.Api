namespace AnimalWeb.Api.Repository.Responce
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }        

        public async Task<RepositoryResponse<List<T>>> GetAllAsync()
        {
            var repository = new RepositoryResponse<List<T>>();
            var entities = await _context.Set<T>()
                .ToListAsync();

            repository.Data = entities;

            return repository;
        }

        public async Task<RepositoryResponse<T>> GetByIdAsync(int id)
        {
            var repository = new RepositoryResponse<T>();
            var entity = await _context.Set<T>()
                .FindAsync(id);

            repository.Data = entity;

            return repository;
        }

        public async Task<RepositoryResponse<T>> CreateAsync<TSource>(TSource source)
        {
            var repository = new RepositoryResponse<T>();
            var entity = _mapper.Map<T>(source);

            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            repository.Data = entity;

            return repository;
        }

        public async Task<RepositoryResponse<T>> UpdateAsync<TSource>(int id, TSource source)
            where TSource : IBaseDto
        {
            var repository = new RepositoryResponse<T>();
            var entity = await _context.Set<T>()
                .FindAsync(id);

            if(entity is null)
                throw new NullReferenceException("Entity is null");

            _mapper.Map(entity, source);
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            repository.Data = entity;

            return repository;
        }

        public async Task<RepositoryResponse<List<T>>> DeleteAsync(int id)
        {
            var repository = new RepositoryResponse<List<T>>();
            var entity = await _context.Set<T>()
                .FindAsync(id);

            if(entity is null)
                throw new NotFoundException(nameof(entity), id);

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            repository.Data = await _context.Set<T>().ToListAsync();

            return repository;
        }
    }
}