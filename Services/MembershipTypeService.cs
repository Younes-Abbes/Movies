using WebApplication1.Data.Repositories;
using WebApplication1.Models.DomainModels;
namespace WebApplication1.Services
{
    public interface IMembershipTypeService : IGenericService<Memebershiptype>
    {
        Task<IEnumerable<Memebershiptype>> GetAllAsync();
        Task<Memebershiptype> GetById(Guid id);
        Task<Memebershiptype> CreateUserAsync(Memebershiptype userDto);
        void Update(Memebershiptype entity);
        void Delete(Memebershiptype entity);
        void Add(Memebershiptype entity);
        void Save();
    }
    public class MembershipTypeService : GenericService<Memebershiptype>
    {
        private readonly IGenericRepository<Memebershiptype> _context;
        public MembershipTypeService(IGenericRepository<Memebershiptype> context) : base(context)
        {
            _context = context;
        }
    }
}
