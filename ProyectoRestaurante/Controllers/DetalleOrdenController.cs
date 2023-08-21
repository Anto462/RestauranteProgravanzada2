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
    public class DetalleOrdenController : Controller
    {
        private readonly RestauranteContext _context;

        public DetalleOrdenController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: DetalleOrden
        public async Task<IActionResult> Index()
        {
            var restauranteContext = _context.DetalleOrdens.Include(d => d.IdOrdenNavigation).Include(d => d.IdPlatoNavigation);
            return View(await restauranteContext.ToListAsync());
        }

        // GET: DetalleOrden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleOrdens == null)
            {
                return NotFound();
            }

            var detalleOrden = await _context.DetalleOrdens
                .Include(d => d.IdOrdenNavigation)
                .Include(d => d.IdPlatoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleOrden == id);
            if (detalleOrden == null)
            {
                return NotFound();
            }

            return View(detalleOrden);
        }

        // GET: DetalleOrden/Create
        public IActionResult Create()
        {
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden");
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "NombrePlato");
            return View();
        }

        // POST: DetalleOrden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleOrden,IdOrden,IdPlato,Cantidad,PrecioUnitario")] DetalleOrden detalleOrden)
        {
            
            if (detalleOrden.Cantidad != null)
            {
                var plato = await _context.Menus.FindAsync(detalleOrden.IdPlato);
                detalleOrden.PrecioUnitario = plato.Precio * detalleOrden.Cantidad;

                _context.Add(detalleOrden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden", detalleOrden.IdOrden);
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "IdPlato", detalleOrden.IdPlato);
            return View(detalleOrden);
        }

        // GET: DetalleOrden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleOrdens == null)
            {
                return NotFound();
            }

            var detalleOrden = await _context.DetalleOrdens.FindAsync(id);
            if (detalleOrden == null)
            {
                return NotFound();
            }
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden", detalleOrden.IdOrden);
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "IdPlato", detalleOrden.IdPlato);
            return View(detalleOrden);
        }

        // POST: DetalleOrden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleOrden,IdOrden,IdPlato,Cantidad,PrecioUnitario")] DetalleOrden detalleOrden)
        {
            detalleOrden.PrecioUnitario = detalleOrden.IdPlatoNavigation.Precio * detalleOrden.Cantidad;
            if (id != detalleOrden.IdDetalleOrden)
            {
                return NotFound();
            }

            if (detalleOrden.Cantidad != null)
            {
                try
                {
                    _context.Update(detalleOrden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleOrdenExists(detalleOrden.IdDetalleOrden))
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
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden", detalleOrden.IdOrden);
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "IdPlato", detalleOrden.IdPlato);
            return View(detalleOrden);
        }

        // GET: DetalleOrden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleOrdens == null)
            {
                return NotFound();
            }

            var detalleOrden = await _context.DetalleOrdens
                .Include(d => d.IdOrdenNavigation)
                .Include(d => d.IdPlatoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleOrden == id);
            if (detalleOrden == null)
            {
                return NotFound();
            }

            return View(detalleOrden);
        }

        // POST: DetalleOrden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleOrdens == null)
            {
                return Problem("Entity set 'RestauranteContext.DetalleOrdens'  is null.");
            }
            var detalleOrden = await _context.DetalleOrdens.FindAsync(id);
            if (detalleOrden != null)
            {
                _context.DetalleOrdens.Remove(detalleOrden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleOrdenExists(int id)
        {
          return (_context.DetalleOrdens?.Any(e => e.IdDetalleOrden == id)).GetValueOrDefault();
        }
    }
}
