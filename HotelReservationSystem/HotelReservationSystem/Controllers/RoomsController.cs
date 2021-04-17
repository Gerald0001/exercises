using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelReservationDbContext _context;

        public RoomsController(HotelReservationDbContext context)
        {
            _context = context;
        }

        // GET: RoomsController
        public async Task<ActionResult> Index(int roomNo)
        {
            var queryableRooms =  _context.Rooms.Include(x => x.Tenants).AsQueryable();

            if (roomNo > 0)
            {
                queryableRooms = queryableRooms.Where(x => x.RoomNo == roomNo);
            }

            return View(await queryableRooms.ToListAsync());
        }

        // GET: RoomsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            return View(room);
        }

        // POST: RoomsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Room room)
        {
            var dataRoom = await _context.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            dataRoom.Id = room.Id;
            dataRoom.RoomFloor = room.RoomFloor;
            dataRoom.RoomNo = room.RoomNo;
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: RoomsController/Delete/5
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
