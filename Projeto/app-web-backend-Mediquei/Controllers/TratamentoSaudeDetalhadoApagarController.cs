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
    public class TratamentoSaudeDetalhadoApagarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TratamentoSaudeDetalhadoApagarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TratamentoSaudeDetalhadoApagar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TratamentosSaudeDet.Include(t => t.EfeitoAdverso1).Include(t => t.EfeitoAdverso2).Include(t => t.EfeitoAdverso3).Include(t => t.Medicamento).Include(t => t.TratamentoSaude);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TratamentoSaudeDetalhadoApagar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoSaudeDet = await _context.TratamentosSaudeDet
                .Include(t => t.EfeitoAdverso1)
                .Include(t => t.EfeitoAdverso2)
                .Include(t => t.EfeitoAdverso3)
                .Include(t => t.Medicamento)
                .Include(t => t.TratamentoSaude)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamentoSaudeDet == null)
            {
                return NotFound();
            }

            return View(tratamentoSaudeDet);
        }

        // GET: TratamentoSaudeDetalhadoApagar/Create
        public IActionResult Create()
        {
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao");
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao");
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao");
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome");
            ViewData["TratamentoId"] = new SelectList(_context.TratamentosSaude, "Id", "Id");
            return View();
        }

        // POST: TratamentoSaudeDetalhadoApagar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TratamentoId,MedicamentoId,Posologia,Observacao,DataInicial,DataFinal,HoraInicial,intervalo,EfeitoId1,EfeitoId2,EfeitoId3")] TratamentoSaudeDet tratamentoSaudeDet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamentoSaudeDet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId3);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome", tratamentoSaudeDet.MedicamentoId);
            ViewData["TratamentoId"] = new SelectList(_context.TratamentosSaude, "Id", "Id", tratamentoSaudeDet.TratamentoId);
            return View(tratamentoSaudeDet);
        }

        // GET: TratamentoSaudeDetalhadoApagar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoSaudeDet = await _context.TratamentosSaudeDet.FindAsync(id);
            if (tratamentoSaudeDet == null)
            {
                return NotFound();
            }
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId3);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome", tratamentoSaudeDet.MedicamentoId);
            ViewData["TratamentoId"] = new SelectList(_context.TratamentosSaude, "Id", "Id", tratamentoSaudeDet.TratamentoId);
            return View(tratamentoSaudeDet);
        }

        // POST: TratamentoSaudeDetalhadoApagar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TratamentoId,MedicamentoId,Posologia,Observacao,DataInicial,DataFinal,HoraInicial,intervalo,EfeitoId1,EfeitoId2,EfeitoId3")] TratamentoSaudeDet tratamentoSaudeDet)
        {
            if (id != tratamentoSaudeDet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamentoSaudeDet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamentoSaudeDetExists(tratamentoSaudeDet.Id))
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
            ViewData["EfeitoId1"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.EfeitosAdversos, "Id", "Descricao", tratamentoSaudeDet.EfeitoId3);
            ViewData["MedicamentoId"] = new SelectList(_context.Medicamentos, "Id", "Nome", tratamentoSaudeDet.MedicamentoId);
            ViewData["TratamentoId"] = new SelectList(_context.TratamentosSaude, "Id", "Id", tratamentoSaudeDet.TratamentoId);
            return View(tratamentoSaudeDet);
        }

        // GET: TratamentoSaudeDetalhadoApagar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoSaudeDet = await _context.TratamentosSaudeDet
                .Include(t => t.EfeitoAdverso1)
                .Include(t => t.EfeitoAdverso2)
                .Include(t => t.EfeitoAdverso3)
                .Include(t => t.Medicamento)
                .Include(t => t.TratamentoSaude)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamentoSaudeDet == null)
            {
                return NotFound();
            }

            return View(tratamentoSaudeDet);
        }

        // POST: TratamentoSaudeDetalhadoApagar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tratamentoSaudeDet = await _context.TratamentosSaudeDet.FindAsync(id);
            _context.TratamentosSaudeDet.Remove(tratamentoSaudeDet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamentoSaudeDetExists(int id)
        {
            return _context.TratamentosSaudeDet.Any(e => e.Id == id);
        }
    }
}
