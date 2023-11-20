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
    public class CamionesController : Controller
    {
        private readonly CamionesContext _context;

        public CamionesController(CamionesContext context)
        {
            _context = context;
        }

        // GET: Camiones
        public async Task<IActionResult> Index()
        {
              return _context.Camiones != null ? 
                          View(await _context.Camiones.ToListAsync()) :
                          Problem("Entity set 'CamionesContext.Camiones'  is null.");
        }

        // GET: Camiones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Camiones == null)
            {
                return NotFound();
            }

            var camione = await _context.Camiones
                .FirstOrDefaultAsync(m => m.Patente == id);
            if (camione == null)
            {
                return NotFound();
            }

            return View(camione);
        }

        // GET: Camiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCamionero,Marca,Patente,TipoCamion,PesoCamion,PesoCarga,GpsCc")] Camione camione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camione);
        }

        // GET: Camiones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Camiones == null)
            {
                return NotFound();
            }

            var camione = await _context.Camiones.FindAsync(id);
            if (camione == null)
            {
                return NotFound();
            }
            return View(camione);
        }

        // POST: Camiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCamionero,Marca,Patente,TipoCamion,PesoCamion,PesoCarga,GpsCc")] Camione camione)
        {
            if (id != camione.Patente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamioneExists(camione.Patente))
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
            return View(camione);
        }

        // GET: Camiones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Camiones == null)
            {
                return NotFound();
            }

            var camione = await _context.Camiones
                .FirstOrDefaultAsync(m => m.Patente == id);
            if (camione == null)
            {
                return NotFound();
            }

            return View(camione);
        }

        // POST: Camiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Camiones == null)
            {
                return Problem("Entity set 'CamionesContext.Camiones'  is null.");
            }
            var camione = await _context.Camiones.FindAsync(id);
            if (camione != null)
            {
                _context.Camiones.Remove(camione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamioneExists(string id)
        {
          return (_context.Camiones?.Any(e => e.Patente == id)).GetValueOrDefault();
        }
    }
}
