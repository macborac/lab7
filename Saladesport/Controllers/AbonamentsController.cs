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
    public class AbonamentsController : Controller
    {
        private readonly SaladesportContext _context;

        public AbonamentsController(SaladesportContext context)
        {
            _context = context;
        }

        // GET: Abonaments
        public async Task<IActionResult> Index()
        {
            var saladesportContext = _context.Abonaments.Include(a => a.Equipment);
            return View(await saladesportContext.ToListAsync());
        }

        // GET: Abonaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonament = await _context.Abonaments
                .Include(a => a.Equipment)
                .FirstOrDefaultAsync(m => m.AbonamentId == id);
            if (abonament == null)
            {
                return NotFound();
            }

            return View(abonament);
        }

        // GET: Abonaments/Create
        public IActionResult Create()
        {
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentId", "ExerciseName");
            return View();
        }

        // POST: Abonaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Durata,EquipmentID")] Abonament abonament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abonament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentId", "ExerciseName", abonament.EquipmentID);
            return View(abonament);
        }

        // GET: Abonaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonament = await _context.Abonaments.FindAsync(id);
            if (abonament == null)
            {
                return NotFound();
            }
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentId", "ExerciseName", abonament.EquipmentID);
            return View(abonament);
        }

        // POST: Abonaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,Durata,EquipmentID")] Abonament abonament)
        {
            if (id != abonament.AbonamentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abonament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonamentExists(abonament.AbonamentId))
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
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentId", "ExerciseName", abonament.EquipmentID);
            return View(abonament);
        }

        // GET: Abonaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonament = await _context.Abonaments
                .Include(a => a.Equipment)
                .FirstOrDefaultAsync(m => m.AbonamentId == id);
            if (abonament == null)
            {
                return NotFound();
            }

            return View(abonament);
        }

        // POST: Abonaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abonament = await _context.Abonaments.FindAsync(id);
            if (abonament != null)
            {
                _context.Abonaments.Remove(abonament);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbonamentExists(int id)
        {
            return _context.Abonaments.Any(e => e.AbonamentId == id);
        }
    }
}
