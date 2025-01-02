using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DomainModels;

namespace WebApplication1.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<Movie> GetByIdAsync(Guid id)
        {
            var result = await _dbSet.Include(m => m.genres).FirstOrDefaultAsync(m => m.Id == id);
            if (result == null)
            {
                throw new Exception("Movie not found");

            }
            return result;
        }
    }
}
