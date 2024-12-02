
namespace WebApplication1.Models.DomainModels
{
    public class Customer
    {
        public Customer() { }
        public Customer(string name)
        {
            this.Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Memebershiptype? membershipType { get; set; }
        public ICollection<Movie>? movies { get; set; }
    }
}