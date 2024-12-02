using WebApplication1.Models.DomainModels;
namespace WebApplication1.Services
{ 
    public class MovieService : IGenericRepository<Movie>
    {
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Movie entity)
        {
            _context.Movies.Add(entity);
        }

        public void Delete(Movie entity)
        {
            _context.Movies.Remove(entity);
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(Guid id)
        {
            return _context.Movies.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Movie entity)
        {
            _context.Movies.Update(entity);
        }


    }
}
