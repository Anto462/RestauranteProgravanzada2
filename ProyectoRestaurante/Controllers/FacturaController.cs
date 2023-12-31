using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRestaurante.Models2;

namespace ProyectoRestaurante.Controllers
{
    public class FacturaController : Controller
    {
        private readonly RestauranteContext _context;

        public FacturaController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: Factura
        public async Task<IActionResult> Index()
        {
            var restauranteContext = _context.Facturas.Include(f => f.IdDordenNavigation).Include(f => f.IdNavigation);
            return View(await restauranteContext.ToListAsync());
        }
        [HttpGet]
        public async Task<ActionResult> Index(string search)
        {
            ViewData["GetFacturassdetails"] = search;

            var query = from Factura in _context.Facturas
                        .Include(o => o.IdDordenNavigation)
                        .Include(o => o.IdNavigation)
                        select Factura;

            if (!string.IsNullOrEmpty(search))
            {
                if (int.TryParse(search, out int searchNumber))
                {
                    query = query.Where(o => o.IdDorden == searchNumber);
                }
                else
                {
                    query = query.Where(o => o.IdNavigation.UserName.Contains(search));
                }
            }

            return View(await query.AsNoTracking().ToListAsync());
        }

        // GET: Factura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdDordenNavigation)
                .Include(f => f.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Factura/Create
        public IActionResult Create()
        {
            ViewData["IdDorden"] = new SelectList(_context.DetalleOrdens, "IdDetalleOrden", "IdDetalleOrden");
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Factura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,Id,FechaFactura,HoraFactura,IdDorden,Costototal")] Factura factura)
        {
            factura.Id = User.Identity.GetUserId();
            factura.FechaFactura = DateTime.Now;
            factura.HoraFactura = DateTime.Now.TimeOfDay;
            if (factura.IdDorden != null)
            {
                var orden = await _context.Ordens.Include(o => o.DetalleOrdens).FirstOrDefaultAsync(o => o.IdOrden == factura.IdDorden);

                if (orden != null)
                {
                    factura.Costototal = (int)orden.DetalleOrdens.Sum(d => d.PrecioUnitario);
                }

                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDorden"] = new SelectList(_context.DetalleOrdens, "IdDetalleOrden", "IdDetalleOrden", factura.IdDorden);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", factura.Id);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IdDorden"] = new SelectList(_context.DetalleOrdens, "IdDetalleOrden", "IdDetalleOrden", factura.IdDorden);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", factura.Id);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,Id,FechaFactura,HoraFactura,IdDorden,Costototal")] Factura factura)
        {
            if (id != factura.IdFactura)
            {
                return NotFound();
            }

            if (factura.HoraFactura != null)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IdFactura))
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
            ViewData["IdDorden"] = new SelectList(_context.DetalleOrdens, "IdDetalleOrden", "IdDetalleOrden", factura.IdDorden);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", factura.Id);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdDordenNavigation)
                .Include(f => f.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Entity set 'RestauranteContext.Facturas'  is null.");
            }
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
          return (_context.Facturas?.Any(e => e.IdFactura == id)).GetValueOrDefault();
        }
    }
}
