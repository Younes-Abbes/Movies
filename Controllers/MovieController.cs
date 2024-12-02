using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DomainModels;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;

namespace AspCoreApplication2023.Controllers
{
    public class MovieController : Controller
    {
        private MovieService _context;
        public MovieController(ApplicationDbContext context)
        {
            this._context = new MovieService(context);
        }
        [ActionName("Index")]
        public IActionResult Index()
        {
            
            List<Movie> movies = _context.GetAll();
            return View(movies);
        }
        public IActionResult Edit(Guid id)
        {
            var movie = _context.GetById(id);
            if (movie != null)
            {
                var movieToEdit = new EditMovieRequest()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    genre_id = movie.genre_id
                };
                return View(movieToEdit);
            }
            return Content("Test Id: " + id);
        }
        [HttpPost]
        public IActionResult Edit(EditMovieRequest newMovie)
        {
            var movie = _context.GetById(newMovie.Id);
            if (movie != null)
            {
                movie.Name = newMovie.Name;
                movie.genre_id = newMovie.genre_id;
                _context.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
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

        
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult add(Movie movie)
        {
            movie.genre_id = _context.GetAll().First().genre_id;
            _context.Add(movie);
            _context.Save();
            return RedirectToAction("Index");
        }
        public IActionResult delete(Guid id) {
            var movie = _context.GetById(id);
            if (movie != null)
            {
                _context.Delete(movie);
                _context.Save();
            }
            return RedirectToAction("index");
        }
    }
}
