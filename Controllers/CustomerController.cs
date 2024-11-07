using AspCoreApplication2023.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController (ApplicationDbContext context)
        {
            this._context = context;
        }
        [ActionName("Index")]
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddCustomer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var name = newCustomer.name;
            var customer = new Customer(name);
            this._context.Customers.Add(customer);
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
