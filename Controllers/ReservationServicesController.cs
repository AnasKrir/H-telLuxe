using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;

public class ReservationServicesController : Controller
{
    private readonly HotelManagementContext _context;

    public ReservationServicesController(HotelManagementContext context)
    {
        _context = context;
    }

    // GET: ReservationServices
    public async Task<IActionResult> Index()
    {
        return View(await _context.ReservationServices
            .Include(rs => rs.Service)
            .Include(rs => rs.Client)
            .ToListAsync());
    }

    // GET: ReservationServices/Create
    public IActionResult Create()
    {
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "NomService");
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email");
        return View();
    }

    // POST: ReservationServices/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ReservationService reservationService)
    {
        if (ModelState.IsValid)
        {
            _context.ReservationServices.Add(reservationService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "NomService", reservationService.ServiceId);
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email", reservationService.ClientId);
        return View(reservationService);
    }

    // GET: ReservationServices/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var reservationService = await _context.ReservationServices.FindAsync(id);
        if (reservationService == null) return NotFound();

        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "NomService", reservationService.ServiceId);
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email", reservationService.ClientId);
        return View(reservationService);
    }

    // POST: ReservationServices/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ReservationService reservationService)
    {
        if (id != reservationService.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(reservationService);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ReservationServices.Any(e => e.Id == reservationService.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "NomService", reservationService.ServiceId);
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email", reservationService.ClientId);
        return View(reservationService);
    }

    // GET: ReservationServices/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var reservationService = await _context.ReservationServices
            .Include(rs => rs.Service)
            .Include(rs => rs.Client)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (reservationService == null) return NotFound();

        return View(reservationService);
    }

    // POST: ReservationServices/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var reservationService = await _context.ReservationServices.FindAsync(id);
        if (reservationService != null)
        {
            _context.ReservationServices.Remove(reservationService);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
