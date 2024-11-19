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
    public class VisitatorsController : Controller
    {
        private readonly SaladesportContext _context;

        public VisitatorsController(SaladesportContext context)
        {
            _context = context;
        }

        // GET: Visitators
        public async Task<IActionResult> Index()
        {
            var saladesportContext = _context.Visitators.Include(v => v.Abonament);
            return View(await saladesportContext.ToListAsync());
        }

        // GET: Visitators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitator = await _context.Visitators
                .Include(v => v.Abonament)
                .FirstOrDefaultAsync(m => m.VisitatorId == id);
            if (visitator == null)
            {
                return NotFound();
            }

            return View(visitator);
        }

        // GET: Visitators/Create
        public IActionResult Create()
        {
            ViewData["AbonamentID"] = new SelectList(_context.Abonaments, "AbonamentId", "Name");
            return View();
        }

        // POST: Visitators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,SecondName,AbonamentName,BirthDay,GettingDate,Mail,AbonamentID")] Visitator visitator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AbonamentID"] = new SelectList(_context.Abonaments, "AbonamentId", "Name", visitator.AbonamentID);
            return View(visitator);
        }

        // GET: Visitators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitator = await _context.Visitators.FindAsync(id);
            if (visitator == null)
            {
                return NotFound();
            }
            ViewData["AbonamentID"] = new SelectList(_context.Abonaments, "AbonamentId", "Name", visitator.AbonamentID);
            return View(visitator);
        }

        // POST: Visitators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,SecondName,AbonamentName,BirthDay,GettingDate,Mail,AbonamentID")] Visitator visitator)
        {
            if (id != visitator.VisitatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitatorExists(visitator.VisitatorId))
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
            ViewData["AbonamentID"] = new SelectList(_context.Abonaments, "AbonamentId", "Name", visitator.AbonamentID);
            return View(visitator);
        }

        // GET: Visitators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitator = await _context.Visitators
                .Include(v => v.Abonament)
                .FirstOrDefaultAsync(m => m.VisitatorId == id);
            if (visitator == null)
            {
                return NotFound();
            }

            return View(visitator);
        }

        // POST: Visitators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitator = await _context.Visitators.FindAsync(id);
            if (visitator != null)
            {
                _context.Visitators.Remove(visitator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitatorExists(int id)
        {
            return _context.Visitators.Any(e => e.VisitatorId == id);
        }
    }
}
