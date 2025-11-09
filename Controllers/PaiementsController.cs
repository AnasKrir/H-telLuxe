using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;

public class PaiementsController : Controller
{
    private readonly HotelManagementContext _context;

    public PaiementsController(HotelManagementContext context)
    {
        _context = context;
    }

    // GET: Paiements
    public async Task<IActionResult> Index()
    {
        return View(await _context.Paiements.ToListAsync());
    }

    // GET: Paiements/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Paiements/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Paiement paiement)
    {
        if (ModelState.IsValid)
        {
            _context.Paiements.Add(paiement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paiement);
    }

    // GET: Paiements/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var paiement = await _context.Paiements.FindAsync(id);
        if (paiement == null) return NotFound();

        return View(paiement);
    }

    // POST: Paiements/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Paiement paiement)
    {
        if (id != paiement.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(paiement);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Paiements.Any(e => e.Id == paiement.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(paiement);
    }

    // GET: Paiements/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var paiement = await _context.Paiements.FirstOrDefaultAsync(m => m.Id == id);
        if (paiement == null) return NotFound();

        return View(paiement);
    }

    // POST: Paiements/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var paiement = await _context.Paiements.FindAsync(id);
        if (paiement != null)
        {
            _context.Paiements.Remove(paiement);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Paiements/MesPaiements
public async Task<IActionResult> MesPaiements()
{
    var userId = User.Identity.Name; // L'utilisateur connecté
    var paiements = await _context.Paiements
        .Where(p => p.Client.Email == userId) // Reliez l'email au client
        .ToListAsync();

    return View(paiements);
}

}
