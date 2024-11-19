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
    public class FilialesController : Controller
    {
        private readonly SaladesportContext _context;

        public FilialesController(SaladesportContext context)
        {
            _context = context;
        }

        // GET: Filiales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filiales.ToListAsync());
        }

        // GET: Filiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiale = await _context.Filiales
                .FirstOrDefaultAsync(m => m.FilialeId == id);
            if (filiale == null)
            {
                return NotFound();
            }

            return View(filiale);
        }

        // GET: Filiales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Locatia")] Filiale filiale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiale);
        }

        // GET: Filiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiale = await _context.Filiales.FindAsync(id);
            if (filiale == null)
            {
                return NotFound();
            }
            return View(filiale);
        }

        // POST: Filiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Locatia")] Filiale filiale)
        {
            if (id != filiale.FilialeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialeExists(filiale.FilialeId))
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
            return View(filiale);
        }

        // GET: Filiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiale = await _context.Filiales
                .FirstOrDefaultAsync(m => m.FilialeId == id);
            if (filiale == null)
            {
                return NotFound();
            }

            return View(filiale);
        }

        // POST: Filiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filiale = await _context.Filiales.FindAsync(id);
            if (filiale != null)
            {
                _context.Filiales.Remove(filiale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialeExists(int id)
        {
            return _context.Filiales.Any(e => e.FilialeId == id);
        }
    }
}
