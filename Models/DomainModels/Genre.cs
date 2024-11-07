namespace AspCoreApplication2023.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public ICollection<Movie>? movies { get; set; }
    }
}
