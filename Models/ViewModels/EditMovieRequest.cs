using WebApplication1.Models.DomainModels;

namespace WebApplication1.Models.ViewModels
{
    public class EditMovieRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Genre[]? genres { get; set; }

    }
}
