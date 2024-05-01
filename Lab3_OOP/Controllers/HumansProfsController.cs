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
    public class HumansProfsController : Controller
    {
        private readonly AppDbContext _context;

        public HumansProfsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HumansProfs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Student.Include(h => h.Human).Include(h => h.Profession);
            return View(await appDbContext.ToListAsync());
        }

        // GET: HumansProfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humansProf = await _context.Student
                .Include(h => h.Human)
                .Include(h => h.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (humansProf == null)
            {
                return NotFound();
            }

            return View(humansProf);
        }

        // GET: HumansProfs/Create
        public IActionResult Create()
        {
            ViewData["HumanID"] = new SelectList(_context.Human, "Id", "Id");
            ViewData["ProfessionID"] = new SelectList(_context.Klempner, "Id", "Id");
            return View();
        }

        // POST: HumansProfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HumanID,ProfessionID")] HumansProf humansProf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(humansProf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HumanID"] = new SelectList(_context.Human, "Id", "Id", humansProf.HumanID);
            ViewData["ProfessionID"] = new SelectList(_context.Klempner, "Id", "Id", humansProf.ProfessionID);
            return View(humansProf);
        }

        // GET: HumansProfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humansProf = await _context.Student.FindAsync(id);
            if (humansProf == null)
            {
                return NotFound();
            }
            ViewData["HumanID"] = new SelectList(_context.Human, "Id", "Id", humansProf.HumanID);
            ViewData["ProfessionID"] = new SelectList(_context.Klempner, "Id", "Id", humansProf.ProfessionID);
            return View(humansProf);
        }

        // POST: HumansProfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HumanID,ProfessionID")] HumansProf humansProf)
        {
            if (id != humansProf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(humansProf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumansProfExists(humansProf.Id))
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
            ViewData["HumanID"] = new SelectList(_context.Human, "Id", "Id", humansProf.HumanID);
            ViewData["ProfessionID"] = new SelectList(_context.Klempner, "Id", "Id", humansProf.ProfessionID);
            return View(humansProf);
        }

        // GET: HumansProfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var humansProf = await _context.Student
                .Include(h => h.Human)
                .Include(h => h.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (humansProf == null)
            {
                return NotFound();
            }

            return View(humansProf);
        }

        // POST: HumansProfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var humansProf = await _context.Student.FindAsync(id);
            if (humansProf != null)
            {
                _context.Student.Remove(humansProf);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HumansProfExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
