using WebApplication1.Models;

namespace AspCoreApplication2023.Models
{
    public class Customer
    {
        public Customer() { }
        public Customer(string name)
        {
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Memebershiptype? memebershipType { get; set; }
        public ICollection<Movie>? movies { get; set; }
    }
}