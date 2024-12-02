using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DomainModels;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class MembershipTypeController : Controller
    {
        private MembershipTypeService _context;
        public MembershipTypeController(ApplicationDbContext context)
        {
            _context = new MembershipTypeService(context);
        }
        public IActionResult Index()
        {
            var memberships = _context.GetAll();
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
            _context.Add(membership);
            _context.Save();
            return RedirectToAction("Index");
        }
    }
}
