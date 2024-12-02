using WebApplication1.Models.DomainModels;
namespace WebApplication1.Services
{
    public class GenreService : IGenericRepository<Genre>
    {
        private readonly ApplicationDbContext _context;
        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Genre entity)
        {
            _context.Genres.Add(entity);
        }

        public void Delete(Genre entity)
        {
            _context.Genres.Remove(entity);
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre GetById(Guid id)
        {
            return _context.Genres.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Genre entity)
        {
            _context.Genres.Update(entity);
        }
    }
}
