using WebApplication1.Models.DomainModels;
using WebApplication1.Models;

namespace WebApplication1.Models.ViewModels
{
    public class MovieCustomerViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}