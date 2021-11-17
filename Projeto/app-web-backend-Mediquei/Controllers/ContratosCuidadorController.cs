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
    public class ContratosCuidadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContratosCuidadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContratosCuidador
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContratosCuidador.Include(c => c.Cuidador).Include(c => c.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContratosCuidador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratosCuidador = await _context.ContratosCuidador
                .Include(c => c.Cuidador)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratosCuidador == null)
            {
                return NotFound();
            }

            return View(contratosCuidador);
        }

        // GET: ContratosCuidador/Create
        public IActionResult Create()
        {
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Nome");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome");
            return View();
        }

        // POST: ContratosCuidador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CuidadorId,PacienteId,DataInicial,DataFinal,HoraEntrada1,HoraSaida1,HoraEntrada2,HoraSaida2")] ContratosCuidador contratosCuidador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratosCuidador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Nome", contratosCuidador.CuidadorId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", contratosCuidador.PacienteId);
            return View(contratosCuidador);
        }

        // GET: ContratosCuidador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratosCuidador = await _context.ContratosCuidador.FindAsync(id);
            if (contratosCuidador == null)
            {
                return NotFound();
            }
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Nome", contratosCuidador.CuidadorId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", contratosCuidador.PacienteId);
            return View(contratosCuidador);
        }

        // POST: ContratosCuidador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CuidadorId,PacienteId,DataInicial,DataFinal,HoraEntrada1,HoraSaida1,HoraEntrada2,HoraSaida2")] ContratosCuidador contratosCuidador)
        {
            if (id != contratosCuidador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratosCuidador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratosCuidadorExists(contratosCuidador.Id))
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
            ViewData["CuidadorId"] = new SelectList(_context.Cuidadores, "Id", "Nome", contratosCuidador.CuidadorId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", contratosCuidador.PacienteId);
            return View(contratosCuidador);
        }

        // GET: ContratosCuidador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratosCuidador = await _context.ContratosCuidador
                .Include(c => c.Cuidador)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratosCuidador == null)
            {
                return NotFound();
            }

            return View(contratosCuidador);
        }

        // POST: ContratosCuidador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratosCuidador = await _context.ContratosCuidador.FindAsync(id);
            _context.ContratosCuidador.Remove(contratosCuidador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratosCuidadorExists(int id)
        {
            return _context.ContratosCuidador.Any(e => e.Id == id);
        }
    }
}
