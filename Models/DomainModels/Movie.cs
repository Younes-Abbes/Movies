namespace WebApplication1.Models.DomainModels
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string imdbId { get; set; } = "";
        public string Name { get; set; }
        public string? posterUrl { get; set; } = "";
        public ICollection<Customer>? customers { get; set; }
        public ICollection<Genre>? genres { get; set; }
    }
}
