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
    public class MoviesController : Controller
    {
        private readonly VideoRentalDbContext _context;

        public MoviesController(VideoRentalDbContext context)

        {
            _context = context;
        }



        // GET: MoviesController
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.AsNoTracking().ToListAsync());
        }


        // GET: MoviesController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);

            return View(movie);
        }
        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Search(string title, string category)
        {
            var searchResult = _context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                searchResult = searchResult.Where(x => x.Title == title);
            }

            if (!string.IsNullOrEmpty(category))
            {
                searchResult = searchResult.Where(x => x.Category == category);
            }

            return View("Index", searchResult.ToList());

        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie)
        {

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }

        // GET: MoviesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            return View(movie);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Movie model)
        {
            var movie = await _context.Movies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Id = model.Id;
            movie.Title = model.Title;
            movie.Category = model.Category;
            movie.Stock = model.Stock;

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
        public async Task<ActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
