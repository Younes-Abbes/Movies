namespace WebApplication1.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task Update(T entity);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }

}
