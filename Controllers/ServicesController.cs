using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;

public class ServicesController : Controller
{
    private readonly HotelManagementContext _context;

    public ServicesController(HotelManagementContext context)
    {
        _context = context;
    }

    // GET: Services
    public async Task<IActionResult> Index()
    {
        return View(await _context.Services.ToListAsync());
    }

    // GET: Services/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Services/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Service service)
    {
        if (ModelState.IsValid)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(service);
    }

    // GET: Services/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();

        return View(service);
    }

    // POST: Services/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Service service)
    {
        if (id != service.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(service);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Services.Any(e => e.Id == service.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(service);
    }

    // GET: Services/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);
        if (service == null) return NotFound();

        return View(service);
    }

    // POST: Services/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service != null)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Services/Disponibles
public async Task<IActionResult> Disponibles()
{
    var servicesDisponibles = await _context.Services.ToListAsync();
    return View(servicesDisponibles);
}

}
