using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DomainModels;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class MembershipTypeController : Controller
    {
        private IGenericService<Memebershiptype> _context;
        public MembershipTypeController(IGenericService<Memebershiptype> context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var memberships = await _context.GetAllAsync();
            return View(memberships);
        }
        [HttpGet]

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(Memebershiptype membership)
        {
            await _context.AddAsync(membership);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
