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
    public class CustomersRentsController : Controller
    {
        private readonly VideoRentalDbContext _context;

        public CustomersRentsController(VideoRentalDbContext context)
        {
            _context = context;
        }
        // GET: CustomersRentsController1
        public async Task<ActionResult> Index()
        {
            var customerRents = await _context.CustomersRents
                    .Include(x => x.Customer)
                    .Include(x => x.Movie)
                    .ToListAsync();

            return View(customerRents);
        }

        // GET: CustomersRentsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersRentsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersRentsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerRent model)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == model.MovieId);

            movie.Stock = movie.Stock - 1;

            _context.Movies.Update(movie);

            await _context.CustomersRents.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: CustomersRentsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersRentsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersRentsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersRentsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
