using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRestaurante.Models2;

namespace ProyectoRestaurante.Controllers
{
    public class RecomendacionController : Controller
    {
        private readonly RestauranteContext _context;

        public RecomendacionController(RestauranteContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Recomendacion
        public async Task<IActionResult> Index()
        {
            var restauranteContext = _context.Recomendacions.Include(r => r.IdNavigation).Include(r => r.IdPlatoNavigation);
            return View(await restauranteContext.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> IndexUsr()
        {
            var restauranteContext = _context.Recomendacions.Include(r => r.IdNavigation).Include(r => r.IdPlatoNavigation);
            return View(await restauranteContext.ToListAsync());
        }

        // GET: Recomendacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recomendacions == null)
            {
                return NotFound();
            }

            var recomendacion = await _context.Recomendacions
                .Include(r => r.IdNavigation)
                .Include(r => r.IdPlatoNavigation)
                .FirstOrDefaultAsync(m => m.IdRecomendacion == id);
            if (recomendacion == null)
            {
                return NotFound();
            }

            return View(recomendacion);
        }
        
        // GET: Recomendacion/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "NombrePlato");
            return View();
        }

        // POST: Recomendacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecomendacion,Id,IdPlato,Comentario")] Recomendacion recomendacion)
        {
            recomendacion.Id = User.Identity.GetUserId();
            if (recomendacion.Comentario != null)
            {
                _context.Add(recomendacion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", recomendacion.Id);
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "IdPlato", recomendacion.IdPlato);
            return View(recomendacion);
        }

        // GET: Recomendacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recomendacions == null)
            {
                return NotFound();
            }

            var recomendacion = await _context.Recomendacions.FindAsync(id);
            if (recomendacion == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", recomendacion.Id);
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "IdPlato", recomendacion.IdPlato);
            return View(recomendacion);
        }

        // POST: Recomendacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecomendacion,Id,IdPlato,Comentario")] Recomendacion recomendacion)
        {
            if (id != recomendacion.IdRecomendacion)
            {
                return NotFound();
            }

            if (recomendacion.Comentario != null)
            {
                try
                {
                    _context.Update(recomendacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecomendacionExists(recomendacion.IdRecomendacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            ViewData["Id"] = new SelectList(_context.AspNetUsers, "Id", "Id", recomendacion.Id);
            ViewData["IdPlato"] = new SelectList(_context.Menus, "IdPlato", "IdPlato", recomendacion.IdPlato);
            return View(recomendacion);
        }

        // GET: Recomendacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recomendacions == null)
            {
                return NotFound();
            }

            var recomendacion = await _context.Recomendacions
                .Include(r => r.IdNavigation)
                .Include(r => r.IdPlatoNavigation)
                .FirstOrDefaultAsync(m => m.IdRecomendacion == id);
            if (recomendacion == null)
            {
                return NotFound();
            }

            return View(recomendacion);
        }

        // POST: Recomendacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recomendacions == null)
            {
                return Problem("Entity set 'RestauranteContext.Recomendacions'  is null.");
            }
            var recomendacion = await _context.Recomendacions.FindAsync(id);
            if (recomendacion != null)
            {
                _context.Recomendacions.Remove(recomendacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecomendacionExists(int id)
        {
          return (_context.Recomendacions?.Any(e => e.IdRecomendacion == id)).GetValueOrDefault();
        }
    }
}
