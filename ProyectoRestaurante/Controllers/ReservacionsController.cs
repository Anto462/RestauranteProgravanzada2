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
    public class ReservacionsController : Controller
    {
        private readonly RestauranteContext _context;

        public ReservacionsController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: Reservacions
        public async Task<IActionResult> Index()
        {
            var restauranteContext = _context.Reservacions.Include(r => r.IdMesaNavigation).Include(r => r.IdNavigation);
            return View(await restauranteContext.ToListAsync());
        }

        // GET: Reservacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions
                .Include(r => r.IdMesaNavigation)
                .Include(r => r.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // GET: Reservacions/Create
        public IActionResult Create(int? capacidadRequerida)
        {
            // Verificar si la capacidadRequerida se proporcionó o no.
            if (capacidadRequerida == null)
            {
                return RedirectToAction("IngresarCapacidad");
            }

            // Filtrar las mesas que cumplen con el requisito de capacidad y seleccionar solo el IdMesa.
            var mesasValidas = _context.Mesas
                .Where(m => m.Capacidad >= capacidadRequerida && m.Estado.Equals("Inactivo"))
                .Select(m => new { Value = m.IdMesa, Text = m.IdMesa })
                .ToList();

            ViewBag.IdMesa = new SelectList(mesasValidas, "Value", "Text");
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");

            // Crear una nueva instancia de Reservacion con la capacidad requerida.
            var nuevaReservacion = new Reservacion
            {
                CantidadPersonas = capacidadRequerida.Value // Asignamos la capacidad requerida a la propiedad CantidadPersonas.
            };

            return View(nuevaReservacion);
        }

        // POST: Reservacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReservacion,Id,FechaReserva,HoraReserva,CantidadPersonas,IdMesa")] Reservacion reservacion)
        {
            reservacion.Id = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _context.Add(reservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMesa"] = new SelectList(_context.Mesas, "IdMesa", "IdMesa", reservacion.IdMesa);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", reservacion.Id);
            return View(reservacion);
        }

        public IActionResult IngresarCapacidad()
        {
            return View();
        }

        // GET: Reservacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }
            ViewData["IdMesa"] = new SelectList(_context.Mesas, "IdMesa", "IdMesa", reservacion.IdMesa);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", reservacion.Id);
            return View(reservacion);
        }

        // POST: Reservacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReservacion,Id,FechaReserva,HoraReserva,CantidadPersonas,IdMesa")] Reservacion reservacion)
        {
            if (id != reservacion.IdReservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionExists(reservacion.IdReservacion))
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
            ViewData["IdMesa"] = new SelectList(_context.Mesas, "IdMesa", "IdMesa", reservacion.IdMesa);
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", reservacion.Id);
            return View(reservacion);
        }

        // GET: Reservacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservacions == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacions
                .Include(r => r.IdMesaNavigation)
                .Include(r => r.IdNavigation)
                .FirstOrDefaultAsync(m => m.IdReservacion == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // POST: Reservacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservacions == null)
            {
                return Problem("Entity set 'RestauranteContext.Reservacions'  is null.");
            }
            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion != null)
            {
                _context.Reservacions.Remove(reservacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionExists(int id)
        {
          return (_context.Reservacions?.Any(e => e.IdReservacion == id)).GetValueOrDefault();
        }
    }
}
