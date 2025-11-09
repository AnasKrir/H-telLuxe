using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HotelManagement.Models;
using System.Threading.Tasks;

public class ReservationsController : Controller
{
    private readonly HotelManagementContext _context;

    public ReservationsController(HotelManagementContext context)
    {
        _context = context;
    }

    // GET: Reservations
    public async Task<IActionResult> Index()
    {
        return View(await _context.Reservations
            .Include(r => r.Client)
            .Include(r => r.Chambre)
            .ToListAsync());
    }

    // GET: Reservations/Create
    public IActionResult Create()
    {
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email");
        ViewData["ChambreId"] = new SelectList(_context.Chambres, "Id", "Type");
        return View();
    }

    // POST: Reservations/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email", reservation.ClientId);
        ViewData["ChambreId"] = new SelectList(_context.Chambres, "Id", "Type", reservation.ChambreId);
        return View(reservation);
    }

    // GET: Reservations/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null) return NotFound();

        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email", reservation.ClientId);
        ViewData["ChambreId"] = new SelectList(_context.Chambres, "Id", "Type", reservation.ChambreId);
        return View(reservation);
    }

    // POST: Reservations/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Reservation reservation)
    {
        if (id != reservation.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Reservations.Any(e => e.Id == reservation.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Email", reservation.ClientId);
        ViewData["ChambreId"] = new SelectList(_context.Chambres, "Id", "Type", reservation.ChambreId);
        return View(reservation);
    }

    // GET: Reservations/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var reservation = await _context.Reservations
            .Include(r => r.Client)
            .Include(r => r.Chambre)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (reservation == null) return NotFound();

        return View(reservation);
    }

    // POST: Reservations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Reservations/MesReservations
public async Task<IActionResult> MesReservations()
{
    var userId = User.Identity.Name; // L'utilisateur connecté
    var reservations = await _context.Reservations
        .Include(r => r.Chambre)
        .Where(r => r.Client.Email == userId) // Reliez l'email au client
        .ToListAsync();

    return View(reservations);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Annuler(int id)
{
    var reservation = await _context.Reservations.FindAsync(id);
    if (reservation == null) return NotFound();

    reservation.Status = "Annulée";
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(MesReservations));
}


}
