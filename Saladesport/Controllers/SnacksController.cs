using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saladesport.Models;

namespace Saladesport.Controllers
{
    public class SnacksController : Controller
    {
        private readonly SaladesportContext _context;

        public SnacksController(SaladesportContext context)
        {
            _context = context;
        }

        // GET: Snacks
        public async Task<IActionResult> Index()
        {
            var saladesportContext = _context.Snackses.Include(s => s.Filiales);
            return View(await saladesportContext.ToListAsync());
        }

        // GET: Snacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snacks = await _context.Snackses
                .Include(s => s.Filiales)
                .FirstOrDefaultAsync(m => m.SnacksId == id);
            if (snacks == null)
            {
                return NotFound();
            }

            return View(snacks);
        }

        // GET: Snacks/Create
        public IActionResult Create()
        {
            ViewData["FilialeID"] = new SelectList(_context.Filiales, "FilialeId", "Locatia");
            return View();
        }

        // POST: Snacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SnacksPrice,Durata,FilialeID")] Snacks snacks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snacks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilialeID"] = new SelectList(_context.Filiales, "FilialeId", "Locatia", snacks.FilialeID);
            return View(snacks);
        }

        // GET: Snacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snacks = await _context.Snackses.FindAsync(id);
            if (snacks == null)
            {
                return NotFound();
            }
            ViewData["FilialeID"] = new SelectList(_context.Filiales, "FilialeId", "Locatia", snacks.FilialeID);
            return View(snacks);
        }

        // POST: Snacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,SnacksPrice,Durata,FilialeID")] Snacks snacks)
        {
            if (id != snacks.SnacksId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snacks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnacksExists(snacks.SnacksId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilialeID"] = new SelectList(_context.Filiales, "FilialeId", "Locatia", snacks.FilialeID);
            return View(snacks);
        }

        // GET: Snacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snacks = await _context.Snackses
                .Include(s => s.Filiales)
                .FirstOrDefaultAsync(m => m.SnacksId == id);
            if (snacks == null)
            {
                return NotFound();
            }

            return View(snacks);
        }

        // POST: Snacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snacks = await _context.Snackses.FindAsync(id);
            if (snacks != null)
            {
                _context.Snackses.Remove(snacks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnacksExists(int id)
        {
            return _context.Snackses.Any(e => e.SnacksId == id);
        }
    }
}
