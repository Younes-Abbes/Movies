using Microsoft.AspNetCore.Mvc;
using AspCoreApplication2023.Models;
using WebApplication1.Models.ViewModels;

namespace AspCoreApplication2023.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "movie 1" },
                new Movie { Id = 2, Name = "movie 2" },
                new Movie { Id = 3, Name = "movie 3" }
            };
            return View(movies);
        }
        public IActionResult Edit(int id)
        {
            return Content("Test Id: " + id);
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
        public IActionResult Details(int id)
        {
            // This is example data. In a real application, you'd fetch this from a database.
            var movie = new Movie { Id = id, Name = $"Movie {id}" };
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Smith" },
                new Customer { Id = 3, Name = "Bob Johnson" }
            };

            var viewModel = new MovieCustomerViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult CustomerDetails(int id)
        {
            // Static data for demonstration
            var customer = new Customer { Id = id, Name = $"Customer {id}" };
            return View(customer);
        }


    }
}
