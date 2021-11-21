using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_web_backend_Mediquei.Models;
using Microsoft.AspNetCore.Authorization;

namespace app_web_backend_Mediquei.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DesafiosSaudeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesafiosSaudeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DesafiosSaude
        public async Task<IActionResult> Index()
        {
            return View(await _context.DesafiosSaude.ToListAsync());
        }

        // GET: DesafiosSaude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desafioSaude = await _context.DesafiosSaude
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desafioSaude == null)
            {
                return NotFound();
            }

            return View(desafioSaude);
        }

        // GET: DesafiosSaude/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DesafiosSaude/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] DesafioSaude desafioSaude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desafioSaude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desafioSaude);
        }

        // GET: DesafiosSaude/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desafioSaude = await _context.DesafiosSaude.FindAsync(id);
            if (desafioSaude == null)
            {
                return NotFound();
            }
            return View(desafioSaude);
        }

        // POST: DesafiosSaude/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] DesafioSaude desafioSaude)
        {
            if (id != desafioSaude.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desafioSaude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesafioSaudeExists(desafioSaude.Id))
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
            return View(desafioSaude);
        }

        // GET: DesafiosSaude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desafioSaude = await _context.DesafiosSaude
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desafioSaude == null)
            {
                return NotFound();
            }

            return View(desafioSaude);
        }

        // POST: DesafiosSaude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desafioSaude = await _context.DesafiosSaude.FindAsync(id);
            _context.DesafiosSaude.Remove(desafioSaude);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesafioSaudeExists(int id)
        {
            return _context.DesafiosSaude.Any(e => e.Id == id);
        }
    }
}
