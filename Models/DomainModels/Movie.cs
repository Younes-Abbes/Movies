namespace WebApplication1.Models.DomainModels
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Customer>? customers { get; set; }
        public Genre? genre_id { get; set; }
    }
}
