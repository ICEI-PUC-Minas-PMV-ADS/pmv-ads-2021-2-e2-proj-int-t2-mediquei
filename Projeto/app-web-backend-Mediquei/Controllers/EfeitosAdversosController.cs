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
    public class EfeitosAdversosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EfeitosAdversosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EfeitosAdversos
        public async Task<IActionResult> Index()
        {
            return View(await _context.EfeitosAdversos.ToListAsync());
        }

        // GET: EfeitosAdversos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efeitoAdverso = await _context.EfeitosAdversos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (efeitoAdverso == null)
            {
                return NotFound();
            }

            return View(efeitoAdverso);
        }

        // GET: EfeitosAdversos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EfeitosAdversos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] EfeitoAdverso efeitoAdverso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(efeitoAdverso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(efeitoAdverso);
        }

        // GET: EfeitosAdversos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efeitoAdverso = await _context.EfeitosAdversos.FindAsync(id);
            if (efeitoAdverso == null)
            {
                return NotFound();
            }
            return View(efeitoAdverso);
        }

        // POST: EfeitosAdversos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] EfeitoAdverso efeitoAdverso)
        {
            if (id != efeitoAdverso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(efeitoAdverso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EfeitoAdversoExists(efeitoAdverso.Id))
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
            return View(efeitoAdverso);
        }

        // GET: EfeitosAdversos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var efeitoAdverso = await _context.EfeitosAdversos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (efeitoAdverso == null)
            {
                return NotFound();
            }

            return View(efeitoAdverso);
        }

        // POST: EfeitosAdversos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var efeitoAdverso = await _context.EfeitosAdversos.FindAsync(id);
            _context.EfeitosAdversos.Remove(efeitoAdverso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EfeitoAdversoExists(int id)
        {
            return _context.EfeitosAdversos.Any(e => e.Id == id);
        }
    }
}
