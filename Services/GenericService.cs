using WebApplication1.Data.Repositories;

namespace WebApplication1.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();  // Explicit SaveChanges call
            return entity;
        }

        public async Task Update(T entity)
        {
            _repository.Update(entity);
        }

        async Task IGenericService<T>.DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }

}
