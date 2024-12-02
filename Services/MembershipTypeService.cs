using WebApplication1.Models.DomainModels;
namespace WebApplication1.Services
{
    public class MembershipTypeService : IGenericRepository<Memebershiptype>
    {
        private readonly ApplicationDbContext _context;
        public MembershipTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Memebershiptype entity)
        {
            _context.memebershipTypes.Add(entity);
        }

        public void Delete(Memebershiptype entity)
        {
            _context.memebershipTypes.Remove(entity);
        }

        public List<Memebershiptype> GetAll()
        {
            return _context.memebershipTypes.ToList();
        }

        public Memebershiptype GetById(Guid id)
        {
            return _context.memebershipTypes.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Memebershiptype entity)
        {
            _context.memebershipTypes.Update(entity);
        }
    }
}
