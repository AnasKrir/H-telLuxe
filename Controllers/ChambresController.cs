using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks; 
using HotelManagement.Models;

public class ChambresController : Controller
{
    private readonly HotelManagementContext _context;

    public ChambresController(HotelManagementContext context)
    {
        _context = context;
    }

    // GET: Chambres
    public async Task<IActionResult> Index()
    {
        return View(await _context.Chambres.ToListAsync());
    }

    // GET: Chambres/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Chambres/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Chambre chambre)
    {
        if (ModelState.IsValid)
        {
            _context.Chambres.Add(chambre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(chambre);
    }

    // GET: Chambres/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var chambre = await _context.Chambres.FindAsync(id);
        if (chambre == null) return NotFound();

        return View(chambre);
    }

    // POST: Chambres/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Chambre chambre)
    {
        if (id != chambre.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(chambre);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Chambres.Any(e => e.Id == chambre.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(chambre);
    }

    // GET: Chambres/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var chambre = await _context.Chambres.FirstOrDefaultAsync(m => m.Id == id);
        if (chambre == null) return NotFound();

        return View(chambre);
    }

    // POST: Chambres/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var chambre = await _context.Chambres.FindAsync(id);
        if (chambre != null)
        {
            _context.Chambres.Remove(chambre);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Chambres/Disponibles
public async Task<IActionResult> Disponibles()
{
    var chambresDisponibles = await _context.Chambres
        .Where(c => c.Disponibilite == "Disponible")
        .ToListAsync();

    return View(chambresDisponibles);
}

}
