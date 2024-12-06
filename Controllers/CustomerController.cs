using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;
using WebApplication1.Models.DomainModels;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGenericService<Customer> _customerService;
        private readonly IGenericService<Memebershiptype> _membershipService;

        public CustomerController(IGenericService<Customer> customerService, IGenericService<Memebershiptype> membershipService)
        {
            _customerService = customerService;
            _membershipService = membershipService;
        }
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();
            return View(customers);
        }
        public async Task<IActionResult> Create()
        {
            var memberships = await _membershipService.GetAllAsync();
            ViewBag.memberships = memberships.Select(membership => new SelectListItem() { Text = "membership " + membership.Id.ToString(), Value= @membership.Id.ToString()});
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var membershipType = newCustomer.membershipType;

            await _customerService.AddAsync(newCustomer);
             await _customerService.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
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
        public async Task<IActionResult> Edit(EditCustomerRequest newCustomer)
        {
            var customer = await _customerService.GetByIdAsync(newCustomer.Id);
            if (customer != null)
            {
                customer.Name = newCustomer.Name;
                customer.membershipType = newCustomer.membershipType;
                await _customerService.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer)
        {
            await _customerService.DeleteAsync(customer.Id);
            await _customerService.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
