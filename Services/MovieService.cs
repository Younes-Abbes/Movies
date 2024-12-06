using WebApplication1.Models.DomainModels;
using WebApplication1.Data.Repositories;
namespace WebApplication1.Services
{
    public interface IMovieService : IGenericService<Movie>
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetById(Guid id);
        Task<Movie> CreateUserAsync(Movie userDto);
        void Update(Movie entity);
        void Delete(Movie entity);
        void Add(Movie entity);
        void Save();
    }

    public class MovieService : GenericService<Movie>, IMovieService
    {
        private readonly IGenericRepository<Movie> _context;
        public MovieService(IGenericRepository<Movie> context) : base(context)
        {
            _context = context;
        }

        public async void Add(Movie entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<Movie> CreateUserAsync(Movie userDto)
        {
            await _context.AddAsync(userDto);
            return userDto;
        }

        public void Delete(Movie entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllUsersAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Movie> GetById(Guid id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Movie entity)
        {
            _context.Update(entity);
        }
    }
}
