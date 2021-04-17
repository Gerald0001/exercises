using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Controllers
{
    public class UsersController : Controller
    {
        public readonly HotelReservationDbContext _context;

        public UsersController(HotelReservationDbContext context)
        {
            _context = context;

        }

        // GET: UsersController
        [HttpGet("/")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost("/")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User user)
        {
            var result =
                await _context.Users.FirstOrDefaultAsync(
                    x => x.UserName == user.UserName && x.Password == user.Password);

            if (result != null)
            {
                return RedirectToAction("Index", "Rooms");
            }
            else
            {
                return View(user);
            }

        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var user = await _context.Users.ToListAsync();

            return View(user);

        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            var result =
                await _context.Users.FirstOrDefaultAsync(
                    x => x.UserName == user.UserName);
            if (result != null)
            {
                TempData["ErrorMessage"] = "UserName is Already Exist";
                return RedirectToAction("Index", "Users");
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
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

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: UsersController/Delete/5

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