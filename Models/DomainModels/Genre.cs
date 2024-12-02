namespace WebApplication1.Models.DomainModels
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public ICollection<Movie>? movies { get; set; }
    }
}
