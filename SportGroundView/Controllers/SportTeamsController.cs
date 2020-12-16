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
    public class SportTeamsController : Controller
    {
        private readonly Sport_ground_DBContext _context;

        public SportTeamsController(Sport_ground_DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sport_ground_DBContext = _context.SportTeams.Include(s => s.SportSection);
            return View(await sport_ground_DBContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportTeam = await _context.SportTeams
                .Include(s => s.SportSection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportTeam == null)
            {
                return NotFound();
            }

            return View(sportTeam);
        }

        public IActionResult Create()
        {
            ViewData["SportSectionId"] = new SelectList(_context.SportSections, "Id", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PlayersNumber,DateOfCreation,RewardNumber,SportSectionId")] SportTeam sportTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SportSectionId"] = new SelectList(_context.SportSections, "Id", "Name", sportTeam.SportSectionId);
            return View(sportTeam);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportTeam = await _context.SportTeams.FindAsync(id);
            if (sportTeam == null)
            {
                return NotFound();
            }
            ViewData["SportSectionId"] = new SelectList(_context.SportSections, "Id", "Name", sportTeam.SportSectionId);
            return View(sportTeam);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PlayersNumber,DateOfCreation,RewardNumber,SportSectionId")] SportTeam sportTeam)
        {
            if (id != sportTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportTeamExists(sportTeam.Id))
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
            ViewData["SportSectionId"] = new SelectList(_context.SportSections, "Id", "Name", sportTeam.SportSectionId);
            return View(sportTeam);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportTeam = await _context.SportTeams
                .Include(s => s.SportSection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportTeam == null)
            {
                return NotFound();
            }

            return View(sportTeam);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportTeam = await _context.SportTeams.FindAsync(id);
            _context.SportTeams.Remove(sportTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportTeamExists(int id)
        {
            return _context.SportTeams.Any(e => e.Id == id);
        }
    }
}
