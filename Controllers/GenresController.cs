using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DomainModels;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenericService<Genre> genericService;

        public GenresController(IGenericService<Genre> genericService)
        {
            this.genericService = genericService;
        }
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var genres = await genericService.GetAllAsync();
            return View(genres);
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> add(Genre genre)
        {
            await genericService.AddAsync(genre);
            return RedirectToAction("Index");
        }
    }
}
