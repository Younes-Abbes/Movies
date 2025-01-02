using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models.DomainModels;

namespace WebApplication1.Models.ViewModels
{
    public class AddMovieRequest
    {
        public Guid Id { get; set; }
        public string imdbId { get; set; } = "";
        public string Name { get; set; }
        public string? posterUrl { get; set; } = "";
        public ICollection<Customer>? customers { get; set; }
        public IEnumerable<SelectListItem> genres { get; set; }
        public string[] selectedGenres { get; set; } = [];

    }
}
