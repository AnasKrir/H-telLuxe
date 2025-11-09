using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;

public class ProgrammesFideliteController : Controller
{
    private readonly HotelManagementContext _context;

    public ProgrammesFideliteController(HotelManagementContext context)
    {
        _context = context;
    }

    // GET: ProgrammesFidelite
    public async Task<IActionResult> Index()
    {
        return View(await _context.ProgrammesFidelite.ToListAsync());
    }

    // GET: ProgrammesFidelite/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ProgrammesFidelite/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProgrammeFidelite programme)
    {
        if (ModelState.IsValid)
        {
            _context.ProgrammesFidelite.Add(programme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(programme);
    }

    // GET: ProgrammesFidelite/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var programme = await _context.ProgrammesFidelite.FindAsync(id);
        if (programme == null) return NotFound();

        return View(programme);
    }

    // POST: ProgrammesFidelite/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProgrammeFidelite programme)
    {
        if (id != programme.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(programme);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ProgrammesFidelite.Any(e => e.Id == programme.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(programme);
    }

    // GET: ProgrammesFidelite/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var programme = await _context.ProgrammesFidelite.FirstOrDefaultAsync(m => m.Id == id);
        if (programme == null) return NotFound();

        return View(programme);
    }

    // POST: ProgrammesFidelite/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var programme = await _context.ProgrammesFidelite.FindAsync(id);
        if (programme != null)
        {
            _context.ProgrammesFidelite.Remove(programme);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
