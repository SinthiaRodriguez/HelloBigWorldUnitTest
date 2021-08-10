using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppNetCore5.Data;
using WebAppNetCore5.Models.PruebaMuchosMuchos;
using WebAppNetCore5.Otros;

namespace WebAppNetCore5.Controllers
{
    public class RelacionPersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelacionPersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RelacionPersonas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context
                .RelacionsPersonas
                .Include(r => r.Persona)
                .Include(r => r.PersonaFamiliar).ToListAsync();
            return View(applicationDbContext);
        }

        // GET: RelacionPersonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacionPersona = await _context.RelacionsPersonas
                .Include(r => r.Persona)
                .Include(r => r.PersonaFamiliar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relacionPersona == null)
            {
                return NotFound();
            }

            return View(relacionPersona);
        }

        // GET: RelacionPersonas/Create
        public IActionResult Create()
        {
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Nombre");
            ViewData["PersonaFamiliarId"] = new SelectList(_context.Personas, "Id", "Nombre");
            var tender = EnumHelper.GetDictionary<Parentezco>();
            ViewData["Parentezcos"] = new SelectList(tender, "Key", "Value");
            return View();
        }

        // POST: RelacionPersonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonaId,PersonaFamiliarId,Parentezco")] RelacionPersona relacionPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relacionPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", relacionPersona.PersonaId);
            ViewData["PersonaFamiliarId"] = new SelectList(_context.Personas, "Id", "Id", relacionPersona.PersonaFamiliarId);
            return View(relacionPersona);
        }

        // GET: RelacionPersonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacionPersona = await _context.RelacionsPersonas.FindAsync(id);
            if (relacionPersona == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", relacionPersona.PersonaId);
            ViewData["PersonaFamiliarId"] = new SelectList(_context.Personas, "Id", "Id", relacionPersona.PersonaFamiliarId);
            return View(relacionPersona);
        }

        // POST: RelacionPersonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaId,PersonaFamiliarId,Parentezco")] RelacionPersona relacionPersona)
        {
            if (id != relacionPersona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relacionPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelacionPersonaExists(relacionPersona.Id))
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
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", relacionPersona.PersonaId);
            ViewData["PersonaFamiliarId"] = new SelectList(_context.Personas, "Id", "Id", relacionPersona.PersonaFamiliarId);
            return View(relacionPersona);
        }

        // GET: RelacionPersonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relacionPersona = await _context.RelacionsPersonas
                .Include(r => r.Persona)
                .Include(r => r.PersonaFamiliar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relacionPersona == null)
            {
                return NotFound();
            }

            return View(relacionPersona);
        }

        // POST: RelacionPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relacionPersona = await _context.RelacionsPersonas.FindAsync(id);
            _context.RelacionsPersonas.Remove(relacionPersona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelacionPersonaExists(int id)
        {
            return _context.RelacionsPersonas.Any(e => e.Id == id);
        }
    }
}
