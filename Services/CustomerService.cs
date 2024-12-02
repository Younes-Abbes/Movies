using WebApplication1.Models.DomainModels;
namespace WebApplication1.Services
{
    public class CustomerService : IGenericRepository<Customer>
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }
    }
}
