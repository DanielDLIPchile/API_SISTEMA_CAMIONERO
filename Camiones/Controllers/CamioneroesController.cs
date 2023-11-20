using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Camiones.Models;

namespace Camiones.Controllers
{
    public class CamioneroesController : Controller
    {
        private readonly CamionesContext _context;

        public CamioneroesController(CamionesContext context)
        {
            _context = context;
        }

        // GET: Camioneroes
        public async Task<IActionResult> Index()
        {
            if (_context.Camioneros == null)
            {
                return Problem("Entity set 'CamionesContext.Camioneros' is null.");
            }

            var camioneros = await _context.Camioneros.ToListAsync();
            return View(camioneros);
        }

        // GET: Camioneroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Camioneros == null)
            {
                return NotFound();
            }

            var camionero = await _context.Camioneros.FirstOrDefaultAsync(m => m.Id == id);
            if (camionero == null)
            {
                return NotFound();
            }

            return View(camionero);
        }

        // GET: Camioneroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camioneroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,FechaNacimiento,Genero,EstadoCivil,NumeroHijos")] Camionero camionero)
        {
            
                if (ModelState.IsValid)
                {
                    _context.Add(camionero);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(camionero);
         }
            

        // GET: Camioneroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Camioneros == null)
            {
                return NotFound();
            }

            var camionero = await _context.Camioneros.FindAsync(id);
            if (camionero == null)
            {
                return NotFound();
            }
            return View(camionero);
        }

        // POST: Camioneroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,FechaNacimiento,Genero,EstadoCivil,NumeroHijos")] Camionero camionero)
        {
            if (id != camionero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camionero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamioneroExists(camionero.Id))
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
            return View(camionero);
        }

        // GET: Camioneroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Camioneros == null)
            {
                return NotFound();
            }

            var camionero = await _context.Camioneros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camionero == null)
            {
                return NotFound();
            }

            return View(camionero);
        }

        // POST: Camioneroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Camioneros == null)
            {
                return Problem("Entity set 'CamionesContext.Camioneros'  is null.");
            }
            var camionero = await _context.Camioneros.FindAsync(id);
            if (camionero != null)
            {
                _context.Camioneros.Remove(camionero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamioneroExists(int id)
        {
          return (_context.Camioneros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
