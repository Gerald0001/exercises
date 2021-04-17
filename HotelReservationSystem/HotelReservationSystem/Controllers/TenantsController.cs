using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Controllers
{
    public class TenantsController : Controller
    {
        private readonly HotelReservationDbContext _context;

        public TenantsController(HotelReservationDbContext context)
        {
            _context = context;
        }

        // GET: TenantController
        public async Task<ActionResult> Index()
        {
            var tenants = await _context.Tenants.Include(x => x.Room).ToListAsync();

            return View(tenants);

        }

        // GET: TenantController/Details/5
        public ActionResult Details(int Id)
        {
            return View();
        }

        // GET: TenantController/Create
        public async Task<ActionResult> Create()
        {
            var availableRooms = await _context.Rooms.ToListAsync();
            ViewBag.Rooms = availableRooms;

            return View();
        }

        // POST: TenantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tenant tenant)
        {
            var room = await _context.Rooms.Include(x => x.Tenants).FirstOrDefaultAsync(x => x.Id == tenant.RoomId);

            if (room.RoomType == "Sharing" && room.Tenants.Count == 4)
            {
                TempData["ErrorMessage"] = "Room is fully booked";
            }
            else
            {
                await _context.Tenants.AddAsync(tenant);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));


        }

        // GET: TenantController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var tenant = await _context.Tenants.FirstOrDefaultAsync(x => x.Id == id);

            return View(tenant);
        }

        // POST: TenantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Tenant tenant)
        {
            var datatenant = await _context.Tenants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            
            datatenant.Id = tenant.Id;
            datatenant.FirstName = tenant.FirstName;
            datatenant.LastName = tenant.LastName;
            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: TenantController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);

            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // POST: TenantController/Delete/5
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
