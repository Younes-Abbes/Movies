namespace AspCoreApplication2023.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Customer>? customers { get; set; }
        public Genre? genre_id { get; set; }
    }
}
