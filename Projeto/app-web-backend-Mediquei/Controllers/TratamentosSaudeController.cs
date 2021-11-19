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
    public class TratamentosSaudeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TratamentosSaudeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TratamentosSaude
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TratamentosSaude.Include(t => t.DesafioSaude).Include(t => t.EfeitoAdverso1).Include(t => t.EfeitoAdverso2).Include(t => t.EfeitoAdverso3).Include(t => t.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TratamentosSaude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoSaude = await _context.TratamentosSaude
                .Include(t => t.DesafioSaude)
                .Include(t => t.EfeitoAdverso1)
                .Include(t => t.EfeitoAdverso2)
                .Include(t => t.EfeitoAdverso3)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamentoSaude == null)
            {
                return NotFound();
            }

            return View(tratamentoSaude);
        }

        // GET: TratamentosSaude/Create
        public IActionResult Create()
        {
            ViewData["DesafioId"] = new SelectList(_context.DesafiosSaude, "Id", "Nome");
            ViewData["EfeitoId1"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao");
            ViewData["EfeitoId2"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao");
            ViewData["EfeitoId3"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome");
            return View();
        }

        // POST: TratamentosSaude/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,DesafioId,Posologia,Observacao,DataInicial,DataFinal,HoraInicial,intervalo,EfeitoId1,EfeitoId2,EfeitoId3")] TratamentoSaude tratamentoSaude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamentoSaude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesafioId"] = new SelectList(_context.DesafiosSaude, "Id", "Nome", tratamentoSaude.DesafioId);
            ViewData["EfeitoId1"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId3);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", tratamentoSaude.PacienteId);
            return View(tratamentoSaude);
        }

        // GET: TratamentosSaude/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoSaude = await _context.TratamentosSaude.FindAsync(id);
            if (tratamentoSaude == null)
            {
                return NotFound();
            }
            ViewData["DesafioId"] = new SelectList(_context.DesafiosSaude, "Id", "Nome", tratamentoSaude.DesafioId);
            ViewData["EfeitoId1"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId3);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", tratamentoSaude.PacienteId);
            return View(tratamentoSaude);
        }

        // POST: TratamentosSaude/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,DesafioId,Posologia,Observacao,DataInicial,DataFinal,HoraInicial,intervalo,EfeitoId1,EfeitoId2,EfeitoId3")] TratamentoSaude tratamentoSaude)
        {
            if (id != tratamentoSaude.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamentoSaude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamentoSaudeExists(tratamentoSaude.Id))
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
            ViewData["DesafioId"] = new SelectList(_context.DesafiosSaude, "Id", "Nome", tratamentoSaude.DesafioId);
            ViewData["EfeitoId1"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId1);
            ViewData["EfeitoId2"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId2);
            ViewData["EfeitoId3"] = new SelectList(_context.Set<EfeitoAdverso>(), "Id", "Descricao", tratamentoSaude.EfeitoId3);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", tratamentoSaude.PacienteId);
            return View(tratamentoSaude);
        }

        // GET: TratamentosSaude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tratamentoSaude = await _context.TratamentosSaude
                .Include(t => t.DesafioSaude)
                .Include(t => t.EfeitoAdverso1)
                .Include(t => t.EfeitoAdverso2)
                .Include(t => t.EfeitoAdverso3)
                .Include(t => t.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamentoSaude == null)
            {
                return NotFound();
            }

            return View(tratamentoSaude);
        }

        // POST: TratamentosSaude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tratamentoSaude = await _context.TratamentosSaude.FindAsync(id);
            _context.TratamentosSaude.Remove(tratamentoSaude);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamentoSaudeExists(int id)
        {
            return _context.TratamentosSaude.Any(e => e.Id == id);
        }
    }
}
