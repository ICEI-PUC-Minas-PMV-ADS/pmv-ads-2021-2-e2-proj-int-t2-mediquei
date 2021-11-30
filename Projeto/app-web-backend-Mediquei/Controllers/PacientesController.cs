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
            var applicationDbContext = _context.Pacientes.Include(p => p.Familiar).Include(p => p.Usuario);
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
                .Include(p => p.Familiar)
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
                                            select ce).Count() > 0)
                            };

            var pacienteViewModel = new PacientesViewModel();

            pacienteViewModel.Id = id.Value;
            pacienteViewModel.Nome = paciente.Nome;
            pacienteViewModel.UserId = paciente.UserId;
            pacienteViewModel.FamiliarId = paciente.FamiliarId;
            pacienteViewModel.grauParentesco = paciente.grauParentesco;

            var checkboxListDesafios = new List<CheckBoxViewModel>();

            foreach (var item in TratSaude)
            {
                checkboxListDesafios.Add(new CheckBoxViewModel { IdLookup = item.Id, Nome = item.Nome, Checked = item.Checked });
            }

            pacienteViewModel.DesafiosSaude = checkboxListDesafios;

            return View(pacienteViewModel);
            //return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["FamiliarId"] = new SelectList(_context.Familiares, "Id", "Nome");
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UserId,FamiliarId,grauParentesco")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamiliarId"] = new SelectList(_context.Familiares, "Id", "Nome", paciente.FamiliarId);
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
                                            where (ce.PacienteId == id) & (ce.DesafioSaudeId == c.Id)
                                            select ce).Count() > 0)

                            };
            var pacienteViewModel = new PacientesViewModel();
            pacienteViewModel.Id = id.Value;
            pacienteViewModel.Nome = paciente.Nome;
            pacienteViewModel.FamiliarId = paciente.FamiliarId;
            pacienteViewModel.UserId = paciente.UserId;
            pacienteViewModel.grauParentesco = paciente.grauParentesco;
            var checkboxListDesafios = new List<CheckBoxViewModel>();

            foreach (var item in TratSaude)
            {
                checkboxListDesafios.Add(new CheckBoxViewModel
                {
                    IdLookup = item.Id,
                    Nome = item.Nome,
                    Checked = item.Checked
                });
            }
            pacienteViewModel.DesafiosSaude = checkboxListDesafios;
            ViewData["FamiliarId"] = new SelectList(_context.Familiares, "Id", "Nome", paciente.FamiliarId);
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", paciente.UserId);

            return View(pacienteViewModel);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UserId,FamiliarId,grauParentesco")] PacientesViewModel paciente)
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UserId,FamiliarId,grauParentesco")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
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

                /**** jaque - AQUI SALVA AS ALTERAÇÕES DO CHECKBOX DE DOENÇAS, MAS NÃO ESTÁ FUNCIONANDO****/
                /*var pacienteSelecionado = _context.Pacientes.Find(paciente.Id);

                pacienteSelecionado.Nome = paciente.Nome;
                pacienteSelecionado.UserId = paciente.UserId;
                pacienteSelecionado.FamiliarId = paciente.FamiliarId;
                pacienteSelecionado.grauParentesco = paciente.grauParentesco;

                foreach (var item in _context.TratSaude)
                {
                    if (item.PacienteId == paciente.Id)
                    {
                        _context.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in paciente.DesafiosSaude)
                {                    
                    if (item.Checked)
                    {
                        _context.TratSaude.Add(new TratSaude() { PacienteId = paciente.Id, DesafioSaudeId = item.Id });
                    }
                }

                _context.SaveChanges();*/

                return RedirectToAction(nameof(Index));
            }
            ViewData["FamiliarId"] = new SelectList(_context.Familiares, "Id", "Nome", paciente.FamiliarId);
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", paciente.UserId);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        /*public ActionResult Edit(PacientesViewModel paciente)//[Bind(Include = "EstudanteId,Nome,Idade,Sexo")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                var pacienteSelecionado = _context.Pacientes.Find(paciente.Id);

                pacienteSelecionado.Nome = paciente.Nome;
                pacienteSelecionado.UserId = paciente.UserId;
                pacienteSelecionado.FamiliarId = paciente.FamiliarId;
                pacienteSelecionado.grauParentesco = paciente.grauParentesco;

                foreach (var item in _context.TratSaude)
                {
                    if (item.PacienteId == paciente.Id)
                    {
                        _context.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in paciente.DesafiosSaude)
                {
                    if (item.Checked)
                    {
                        _context.TratSaude.Add(new TratSaude() { PacienteId = paciente.Id, DesafioSaudeId = item.IdLookup });
                    }
                }

                //db.Entry(estudante).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }*/


        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.Familiar)
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
    }
}



