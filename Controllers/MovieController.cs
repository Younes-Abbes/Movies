using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models.DomainModels;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;

namespace AspCoreApplication2023.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _context;
        private readonly IGenericService<Genre> _genresContext;
        public MovieController(IMovieService context, IGenericService<Genre> genresContext)
        {
            _context = context;
            _genresContext = genresContext;
        }
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {

            List<Movie> movies = (List<Movie>)await _context.GetAllAsync();
            return View(movies);
        }
        
        [HttpGet]
        public async Task<IActionResult> add()
        {
            var genres = await _genresContext.GetAllAsync();
            var model = new AddMovieRequest();
            model.selectedGenres = [];
            model.genres = genres.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.GenreName });

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> add(AddMovieRequest addMovieRequest)
        {
            
            var movie = new Movie
            {
                imdbId = addMovieRequest.imdbId,
                Name = addMovieRequest.Name,
                posterUrl = addMovieRequest.posterUrl,
                genres = new List<Genre>(),
            };

            foreach (var genreId in addMovieRequest.selectedGenres)
            {
                var genre = await _genresContext.GetByIdAsync(Guid.Parse(genreId));
                if (genre != null)
                {
                    movie.genres.Add(genre);
                }
            }
            
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("add");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var genres = await _genresContext.GetAllAsync();
            var movie = await _context.GetByIdAsync(id);
            if (movie != null)
            {
                var movieToEdit = new EditMovieRequest()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    genres = [],
                };
                return View(movieToEdit);
            }
            ViewBag.Genres = genres.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.GenreName }).ToArray();
            return Content("Test Id: " + id);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieRequest newMovie)
        {
            var movie = await _context.GetByIdAsync(newMovie.Id);
            if (movie != null)
            {
                movie.Name = newMovie.Name;
                movie.genres = newMovie.genres;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        [HttpGet]
        public async Task<IActionResult> delete(Guid id)
        {
            var movie = await _context.GetByIdAsync(id);
            if (movie != null)
            {
                await _context.DeleteAsync(id);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("index");
        }
        [Route("Movie/released")]
        public IActionResult ByRelease()
        {
            return Content("Please provide a year and month");
        }
        [Route("Movie/released/{year}/{month}")]
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Movies released in {year}/{month}");
        }
        public IActionResult Details(Guid id)
        {
            // This is example data. In a real application, you'd fetch this from a database.
            var movie = new Movie { Id = id, Name = $"Movie {id}" };
            var customers = new List<Customer>
            {
                new Customer { Id = new Guid(), Name = "John Doe" },
                new Customer { Id = new Guid(), Name = "Jane Smith" },
                new Customer { Id = new Guid(), Name = "Bob Johnson" }
            };

            var viewModel = new MovieCustomerViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult CustomerDetails(Guid id)
        {
            // Static data for demonstration
            var customer = new Customer { Id = id, Name = $"Customer {id}" };
            return View(customer);
        }

        
    }
}
