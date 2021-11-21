using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_web_backend_Mediquei.Models;

namespace app_web_backend_Mediquei.Controllers
{
    public class FamiliaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamiliaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Familiares
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Familiares.Include(f => f.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Familiares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiares
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiar == null)
            {
                return NotFound();
            }

            return View(familiar);
        }

        // GET: Familiares/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail");
            return View();
        }

        // POST: Familiares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UserId")] Familiar familiar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", familiar.UserId);
            return View(familiar);
        }

        // GET: Familiares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiares.FindAsync(id);
            if (familiar == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", familiar.UserId);
            return View(familiar);
        }

        // POST: Familiares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UserId")] Familiar familiar)
        {
            if (id != familiar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliarExists(familiar.Id))
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
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", familiar.UserId);
            return View(familiar);
        }

        // GET: Familiares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familiar = await _context.Familiares
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiar == null)
            {
                return NotFound();
            }

            return View(familiar);
        }

        // POST: Familiares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familiar = await _context.Familiares.FindAsync(id);
            _context.Familiares.Remove(familiar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliarExists(int id)
        {
            return _context.Familiares.Any(e => e.Id == id);
        }
    }
}
