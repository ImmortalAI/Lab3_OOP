using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3_OOP.Data;
using Lab3_OOP.Models;

namespace Lab3_OOP.Controllers
{
    public class KlempnersController : Controller
    {
        private readonly AppDbContext _context;

        public KlempnersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Klempners
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Klempner.Include(k => k.Mensch);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Klempners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klempner = await _context.Klempner
                .Include(k => k.Mensch)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klempner == null)
            {
                return NotFound();
            }

            return View(klempner);
        }

        // GET: Klempners/Create
        public IActionResult Create()
        {
            ViewData["MenschID"] = new SelectList(_context.Human, "Id", "Id");
            return View();
        }

        // POST: Klempners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,INN,Gehalt,MenschID")] Klempner klempner)
        {
                _context.Add(klempner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Klempners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klempner = await _context.Klempner.FindAsync(id);
            if (klempner == null)
            {
                return NotFound();
            }
            ViewData["MenschID"] = new SelectList(_context.Human, "Id", "Id", klempner.MenschID);
            return View(klempner);
        }

        // POST: Klempners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,INN,Gehalt,MenschID")] Klempner klempner)
        {
            if (id != klempner.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(klempner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlempnerExists(klempner.Id))
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

        // GET: Klempners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klempner = await _context.Klempner
                .Include(k => k.Mensch)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klempner == null)
            {
                return NotFound();
            }

            return View(klempner);
        }

        // POST: Klempners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klempner = await _context.Klempner.FindAsync(id);
            if (klempner != null)
            {
                _context.Klempner.Remove(klempner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlempnerExists(int id)
        {
            return _context.Klempner.Any(e => e.Id == id);
        }
    }
}
