using WebApplication1.Data.Repositories;
using WebApplication1.Models.DomainModels;
namespace WebApplication1.Services
{
    public class GenreService : GenericService<Genre>
    {
        private readonly IGenericRepository<Genre> _context;
        public GenreService(IGenericRepository<Genre> context) : base(context)
        {
            _context = context;
        }
    }
}
