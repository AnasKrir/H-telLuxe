using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;

public class ReceptionnistesController : Controller
{
    private readonly HotelManagementContext _context;

    public ReceptionnistesController(HotelManagementContext context)
    {
        _context = context;
    }

    // GET: Receptionnistes
    public async Task<IActionResult> Index()
    {
        return View(await _context.Receptionnistes.ToListAsync());
    }

    // GET: Receptionnistes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Receptionnistes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Receptionniste receptionniste)
    {
        if (ModelState.IsValid)
        {
            _context.Receptionnistes.Add(receptionniste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(receptionniste);
    }

    // GET: Receptionnistes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var receptionniste = await _context.Receptionnistes.FindAsync(id);
        if (receptionniste == null) return NotFound();

        return View(receptionniste);
    }

    // POST: Receptionnistes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Receptionniste receptionniste)
    {
        if (id != receptionniste.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(receptionniste);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Receptionnistes.Any(e => e.Id == receptionniste.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(receptionniste);
    }

    // GET: Receptionnistes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var receptionniste = await _context.Receptionnistes.FirstOrDefaultAsync(m => m.Id == id);
        if (receptionniste == null) return NotFound();

        return View(receptionniste);
    }

    // POST: Receptionnistes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var receptionniste = await _context.Receptionnistes.FindAsync(id);
        if (receptionniste != null)
        {
            _context.Receptionnistes.Remove(receptionniste);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Dashboard()
    {
        return View();
    }
    
}
