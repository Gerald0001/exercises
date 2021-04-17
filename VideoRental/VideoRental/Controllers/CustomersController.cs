using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoRental.Models;

namespace VideoRental.Controllers
{
    public class CustomersController : Controller
    {
        private readonly VideoRentalDbContext _context;

        public CustomersController(VideoRentalDbContext context)

        {
            _context = context;
        }



        // GET: CustomersController
        public async Task<IActionResult> Index2()
        {
            return View(await _context.Customers.AsNoTracking().ToListAsync());
        }


        // GET: CustomersController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);

            return View(customer);
        }
        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index2));


        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer model)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Id = model.Id;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Age = model.Age;
            customer.Address = model.Address;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index2));
        }
        
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index2));
        }
    }
}
