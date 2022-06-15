using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newrtest.Views.Home;

namespace Newrtest.Controllers
{
    public class EvenementsController : Controller
    {
        private readonly MvcEvenementContext _context;

        public EvenementsController(MvcEvenementContext context)
        {
            _context = context;
        }

        // GET: Evenements
        public async Task<IActionResult> Index()
        {
              return _context.Evenements != null ? 
                          View(await _context.Evenements.ToListAsync()) :
                          Problem("Entity set 'MvcEvenementContext.Evenements'  is null.");
        }

        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // GET: Evenements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evenement);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            return View(evenement);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementExists(evenement.Id))
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
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evenements == null)
            {
                return Problem("Entity set 'MvcEvenementContext.Evenements'  is null.");
            }
            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement != null)
            {
                _context.Evenements.Remove(evenement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementExists(int id)
        {
          return (_context.Evenements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
