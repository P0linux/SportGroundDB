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
    public class SportTypesController : Controller
    {
        private readonly Sport_ground_DBContext _context;

        public SportTypesController(Sport_ground_DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SportTypes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportType = await _context.SportTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportType == null)
            {
                return NotFound();
            }

            return View(sportType);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsTeamplay")] SportType sportType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportType);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportType = await _context.SportTypes.FindAsync(id);
            if (sportType == null)
            {
                return NotFound();
            }
            return View(sportType);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsTeamplay")] SportType sportType)
        {
            if (id != sportType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportTypeExists(sportType.Id))
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
            return View(sportType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportType = await _context.SportTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportType == null)
            {
                return NotFound();
            }

            return View(sportType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportType = await _context.SportTypes.FindAsync(id);
            _context.SportTypes.Remove(sportType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportTypeExists(int id)
        {
            return _context.SportTypes.Any(e => e.Id == id);
        }
    }
}
