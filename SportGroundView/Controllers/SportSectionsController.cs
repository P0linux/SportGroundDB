using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportGroundView.Models;

namespace SportGroundView.Controllers
{
    public class SportSectionsController : Controller
    {
        private readonly Sport_ground_DBContext _context;

        public SportSectionsController(Sport_ground_DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sport_ground_DBContext = _context.SportSections.Include(s => s.SportType);
            return View(await sport_ground_DBContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportSection = await _context.SportSections
                .Include(s => s.SportType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportSection == null)
            {
                return NotFound();
            }

            return View(sportSection);
        }

        public IActionResult Create()
        {
            ViewData["SportTypeId"] = new SelectList(_context.SportTypes, "Id", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,VisitorsNumber,CoachesNumber,VisitorsMaxNumber,DateOfCreation,SportTypeId")] SportSection sportSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SportTypeId"] = new SelectList(_context.SportTypes, "Id", "Name", sportSection.SportTypeId);
            return View(sportSection);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportSection = await _context.SportSections.FindAsync(id);
            if (sportSection == null)
            {
                return NotFound();
            }
            ViewData["SportTypeId"] = new SelectList(_context.SportTypes, "Id", "Name", sportSection.SportTypeId);
            return View(sportSection);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,VisitorsNumber,CoachesNumber,VisitorsMaxNumber,DateOfCreation,SportTypeId")] SportSection sportSection)
        {
            if (id != sportSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportSectionExists(sportSection.Id))
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
            ViewData["SportTypeId"] = new SelectList(_context.SportTypes, "Id", "Name", sportSection.SportTypeId);
            return View(sportSection);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportSection = await _context.SportSections
                .Include(s => s.SportType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportSection == null)
            {
                return NotFound();
            }

            return View(sportSection);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportSection = await _context.SportSections.FindAsync(id);
            _context.SportSections.Remove(sportSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportSectionExists(int id)
        {
            return _context.SportSections.Any(e => e.Id == id);
        }
    }
}
