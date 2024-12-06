using WebApplication1.Data.Repositories;
using WebApplication1.Models.DomainModels;
namespace WebApplication1.Services
{
    public class CustomerService : GenericService<Customer>
    {
        private readonly IGenericRepository<Customer> _context;
        public CustomerService(IGenericRepository<Customer> context) : base(context)
        {
            _context = context;
        }
    }
}
