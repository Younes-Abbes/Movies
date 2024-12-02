using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;
using WebApplication1.Models.DomainModels;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService _context;
        private MembershipTypeService _membershipService;
        public CustomerController(ApplicationDbContext context)
        {
            this._context = new CustomerService(context);
            this._membershipService = new MembershipTypeService(context);
        }
        [ActionName("Index")]
        public IActionResult Index()
        {
            var customers = _context.GetAll();
            return View(customers);
        }
        public IActionResult Create()
        {
            var memberships = _membershipService.GetAll();
            ViewBag.memberships = memberships.Select(membership => new SelectListItem() { Text = "membership " + membership.Id.ToString(), Value= @membership.Id.ToString()});
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var membershipType = newCustomer.membershipType;

            this._context.Add(newCustomer);
            this._context.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = _context.GetById(id);
            if (customer != null){
                var customerToEdit = new EditCustomerRequest()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    membershipType = customer.membershipType
                };
                return View(customerToEdit);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(EditCustomerRequest newCustomer)
        {
            var customer = _context.GetById(newCustomer.Id);
            if (customer != null)
            {
                customer.Name = newCustomer.Name;
                customer.membershipType = newCustomer.membershipType;
                _context.Save();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var customer = _context.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            _context.Delete(customer);
            _context.Save();
            return RedirectToAction("Index");
        }
    }
}
