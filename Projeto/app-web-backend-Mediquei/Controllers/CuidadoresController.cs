﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_web_backend_Mediquei.Models;

namespace app_web_backend_Mediquei.Controllers
{
    public class CuidadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuidadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cuidadores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cuidadores.Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cuidadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidador == null)
            {
                return NotFound();
            }

            return View(cuidador);
        }

        // GET: Cuidadores/Relatórios/5
        public async Task<IActionResult> Relatorio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //jaque: aqui incluir alguma coisa para conseguir pegar o nome do paciente no relatório de cuidadores, igual feito em TratamentoSaudeDetalhe
            var cuidador = await _context.Cuidadores
                .Include(c => c.ContratoCuidador)    
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidador == null)
            {
                return NotFound();
            }

            //jaque: tentativa de fazer um select em paciente para retornar o nome
            /*var pac = await _context.Pacientes.FindAsync(1);
            if (pac == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", 1);
            */

            /*var pac = from c in _context.Pacientes
                      select new
                            {
                                c.Id,
                                c.Nome                                
                            };
            ViewData["PacienteId"] = new SelectList(pac, "Id", "Nome");*/

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            //ViewData["PacienteIdTodos"] = new SelectList(_context.Pacientes, "Id", "Nome", 2);
            //ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome",contratosCuidador.PacienteId);

            return View(cuidador);            
        }

        // GET: Cuidadores/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail");
            return View();
        }

        // POST: Cuidadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UserId")] Cuidador cuidador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuidador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", cuidador.UserId);
            return View(cuidador);
        }

        // GET: Cuidadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores.FindAsync(id);
            if (cuidador == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", cuidador.UserId);
            return View(cuidador);
        }

        // POST: Cuidadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UserId")] Cuidador cuidador)
        {
            if (id != cuidador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuidador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuidadorExists(cuidador.Id))
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
            ViewData["UserId"] = new SelectList(_context.Usuarios, "Id", "EMail", cuidador.UserId);
            return View(cuidador);
        }

        // GET: Cuidadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidador == null)
            {
                return NotFound();
            }

            return View(cuidador);
        }

        // POST: Cuidadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuidador = await _context.Cuidadores.FindAsync(id);
            _context.Cuidadores.Remove(cuidador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuidadorExists(int id)
        {
            return _context.Cuidadores.Any(e => e.Id == id);
        }
    }
}
