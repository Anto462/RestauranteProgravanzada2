using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRestaurante.Models2;

namespace ProyectoRestaurante.Controllers
{
    public class OrdenController : Controller
    {
        private readonly RestauranteContext _context;

        public OrdenController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: Orden
        public async Task<IActionResult> Index()
        {
            var restauranteContext = _context.Ordens.Include(o => o.IdMesaNavigation).Include(o => o.IdNavigation);
            return View(await restauranteContext.ToListAsync());
        }

        // GET: Orden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .Include(o => o.IdMesaNavigation)
                .Include(o => o.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Orden/Create
        public IActionResult Create()
        {
            ViewData["IdMesa"] = new SelectList(_context.Mesas, "IdMesa", "IdMesa");
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Orden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrden,Id,IdMesa,FechaOrden")] Orden orden)
        {
            if (orden.FechaOrden != null)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMesa"] = new SelectList(_context.Mesas, "IdMesa", "IdMesa", orden.IdMesa);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", orden.Id);
            return View(orden);
        }

        // GET: Orden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["IdMesa"] = new SelectList(_context.Mesas, "IdMesa", "IdMesa", orden.IdMesa);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", orden.Id);
            return View(orden);
        }

        // POST: Orden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrden,Id,IdMesa,FechaOrden")] Orden orden)
        {
            if (id != orden.IdOrden)
            {
                return NotFound();
            }

            if (orden.FechaOrden != null)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.IdOrden))
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
            ViewData["IdMesa"] = new SelectList(_context.Mesas, "IdMesa", "IdMesa", orden.IdMesa);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", orden.Id);
            return View(orden);
        }

        // GET: Orden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .Include(o => o.IdMesaNavigation)
                .Include(o => o.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Orden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordens == null)
            {
                return Problem("Entity set 'RestauranteContext.Ordens'  is null.");
            }
            var orden = await _context.Ordens.FindAsync(id);
            if (orden != null)
            {
                _context.Ordens.Remove(orden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
          return (_context.Ordens?.Any(e => e.IdOrden == id)).GetValueOrDefault();
        }
    }
}
