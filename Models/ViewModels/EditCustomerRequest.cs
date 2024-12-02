using WebApplication1.Models.DomainModels;
namespace WebApplication1.Models.ViewModels
{
    public class EditCustomerRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Memebershiptype? membershipType { get; set; }
    }
}
