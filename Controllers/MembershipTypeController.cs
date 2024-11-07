using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MembershipTypeController : Controller
    {
        private ApplicationDbContext _context;
        public MembershipTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var memberships = _context.memebershipTypes.ToList();
            return View(memberships);
        }
        [HttpGet]

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Memebershiptype membership)
        {
            _context.memebershipTypes.Add(membership);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
