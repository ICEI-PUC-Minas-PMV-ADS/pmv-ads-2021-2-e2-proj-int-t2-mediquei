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
    public class TratSaudeDetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TratSaudeDetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TratSaudeDet
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TratSaudeDet.Include(t => t.EfeitoAdverso1).Include(t => t.EfeitoAdverso2).Include(t => t.EfeitoAdverso3).Include(t => t.Medicamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TratSaudeDet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratSaudeDet = await _context.TratSaudeDet
                .Include(t => t.EfeitoAdverso1)
                .Include(t => t.EfeitoAdverso2)
                .Include(t => t.EfeitoAdverso3)
                .Include(t => t.Medicamento)
                .FirstOrDefaultAsync(m => m.TratSaudeDetId == id);
            if (tratSaudeDet == null)
            {
                return NotFound();
            }

            return View(tratSaudeDet);
        }

        // GET: TratSaudeDet/Create
        public IActionResult Create()
        {
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao");
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao");
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao");
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome");
            return View();
        }

        // POST: TratSaudeDet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TratSaudeDetId,MedicamentoId,Posologia,Observacao,DataInicial,DataFinal,HoraInicial,intervalo,EfeitoId1,EfeitoId2,EfeitoId3")] TratSaudeDet tratSaudeDet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratSaudeDet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId3);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome", tratSaudeDet.MedicamentoId);
            return View(tratSaudeDet);
        }

        // GET: TratSaudeDet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratSaudeDet = await _context.TratSaudeDet.FindAsync(id);
            if (tratSaudeDet == null)
            {
                return NotFound();
            }
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId3);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome", tratSaudeDet.MedicamentoId);
            return View(tratSaudeDet);
        }

        // POST: TratSaudeDet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TratSaudeDetId,MedicamentoId,Posologia,Observacao,DataInicial,DataFinal,HoraInicial,intervalo,EfeitoId1,EfeitoId2,EfeitoId3")] TratSaudeDet tratSaudeDet)
        {
            if (id != tratSaudeDet.TratSaudeDetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratSaudeDet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratSaudeDetExists(tratSaudeDet.TratSaudeDetId))
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
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratSaudeDet.EfeitoId3);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome", tratSaudeDet.MedicamentoId);
            return View(tratSaudeDet);
        }

        // GET: TratSaudeDet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratSaudeDet = await _context.TratSaudeDet
                .Include(t => t.EfeitoAdverso1)
                .Include(t => t.EfeitoAdverso2)
                .Include(t => t.EfeitoAdverso3)
                .Include(t => t.Medicamento)
                .FirstOrDefaultAsync(m => m.TratSaudeDetId == id);
            if (tratSaudeDet == null)
            {
                return NotFound();
            }

            return View(tratSaudeDet);
        }

        // POST: TratSaudeDet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tratSaudeDet = await _context.TratSaudeDet.FindAsync(id);
            _context.TratSaudeDet.Remove(tratSaudeDet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratSaudeDetExists(int id)
        {
            return _context.TratSaudeDet.Any(e => e.TratSaudeDetId == id);
        }
    }
}
