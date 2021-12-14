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
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pacientes.Include(p => p.Usuario);

            if (!User.IsInRole("Admin"))
            {
                // Visualizar apenas o paciente associado ao usuário
                var id = User.Claims.ElementAt(2).Value;
                applicationDbContext =
                       _context.Pacientes
                       .Where(d => d.UserId.ToString() == id)
                       .Include(p => p.Usuario);
            }

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            var TratSaude = from c in _context.DesafiosSaude
                            select new
                            {
                                c.Id,
                                c.Nome,
                                Checked = ((from ce in _context.TratSaude
                                            where (ce.PacienteId == id) & (ce.DesafioSaudeId == c.Id)
                                            select ce.Checked).Count() > 0)
                            };

            var pacienteViewModel = new PacientesViewModel();

            pacienteViewModel.Id = id.Value;
            pacienteViewModel.Nome = paciente.Nome;
            pacienteViewModel.UserId = paciente.UserId;

            var checkboxListTratSaude = new List<CheckBoxViewModel>();

            foreach (var item in TratSaude)
            {
                checkboxListTratSaude.Add(new CheckBoxViewModel
                {
                    IdLookup = item.Id,
                    Nome = item.Nome,
                    Checked = item.Checked
                });
            }

            pacienteViewModel.CheckBoxTratSaude = checkboxListTratSaude;

            return View(pacienteViewModel);
            //return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UserId")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", paciente.UserId);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5                        
        // Função do botão Edit da tela de pacientes
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            var TratSaude = from c in _context.DesafiosSaude
                            select new
                            {
                                c.Id,
                                c.Nome,
                                Checked = ((from ce in _context.TratSaude
                                            where (ce.PacienteId == id) & (ce.DesafioSaudeId == c.Id) &
                                            (ce.Checked == true)
                                            select ce.Checked).Count() > 0)


                            };
            var pacienteViewModel = new PacientesViewModel();
            pacienteViewModel.Id = id.Value;
            pacienteViewModel.Nome = paciente.Nome;
            pacienteViewModel.UserId = paciente.UserId;
            var checkboxListTratSaude = new List<CheckBoxViewModel>();

            foreach (var item in TratSaude)
            {
                checkboxListTratSaude.Add(new CheckBoxViewModel
                {
                    IdLookup = item.Id,
                    Nome = item.Nome,
                    Checked = item.Checked
                });
            }
            pacienteViewModel.CheckBoxTratSaude = checkboxListTratSaude;
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", paciente.UserId);

            return View(pacienteViewModel);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Alterando o método Edit/Post para salvar a seleção feita pelo usuário para os desafios de saúde
        public async Task<IActionResult> Edit(int id, PacientesViewModel pacientevm)
        {

            if (id != pacientevm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var paciente = await _context.Pacientes.FindAsync(id);
                paciente.Nome = pacientevm.Nome;
                paciente.UserId = pacientevm.UserId;

                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                foreach (var item in pacientevm.CheckBoxTratSaude)
                {
                    if (TratSaudeExists(pacientevm.Id, item.IdLookup))
                    {
                        var qryTratSaudeId = from t in _context.TratSaude
                                   .Where(t => t.PacienteId == pacientevm.Id && t.DesafioSaudeId == item.IdLookup)
                                             select new { t.TratSaudeId };

                        foreach (var item2 in qryTratSaudeId)
                        {
                            var tratsaude = await _context.TratSaude.FindAsync(item2.TratSaudeId);

                            tratsaude.Checked = item.Checked;
                            _context.Update(tratsaude);
                        }

                    }
                    else
                    {
                        if (item.Checked)
                        {
                            _context.TratSaude.Add(new TratSaude()
                            {
                                PacienteId = pacientevm.Id,
                                DesafioSaudeId = item.IdLookup,
                                Checked = item.Checked
                            });
                        }
                    }

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", pacientevm.UserId);
            return View(pacientevm);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }

        private bool TratSaudeExists(int idPaciente, int idDesafio)
        {
            return _context.TratSaude.Any(e => e.PacienteId == idPaciente & e.DesafioSaudeId == idDesafio);
        }

    }
}