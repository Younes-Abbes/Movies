

using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);   
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await  _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await  _dbSet.FindAsync(id);
        }


        public async void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _dbSet.Update(entity);
        }

    }

}
