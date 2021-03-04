using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCPrototipo.Models;

namespace MVCPrototipo.Controllers
{
    public class PrecioController : Controller
    {
        private readonly ContextoCursos _context;

        public PrecioController(ContextoCursos context)
        {
            _context = context;
        }

        // GET: Precio
        public async Task<IActionResult> Index()
        {
            var contextoCursos = _context.Precio.Include(p => p.Curso);
            return View(await contextoCursos.ToListAsync());
        }

        // GET: Precio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precio = await _context.Precio
                .Include(p => p.Curso)
                .FirstOrDefaultAsync(m => m.PrecioId == id);
            if (precio == null)
            {
                return NotFound();
            }

            return View(precio);
        }

        // GET: Precio/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId");
            return View();
        }

        // POST: Precio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrecioId,PrecioActual,Promocion,CursoId")] Precio precio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(precio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", precio.CursoId);
            return View(precio);
        }

        // GET: Precio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precio = await _context.Precio.FindAsync(id);
            if (precio == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", precio.CursoId);
            return View(precio);
        }

        // POST: Precio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrecioId,PrecioActual,Promocion,CursoId")] Precio precio)
        {
            if (id != precio.PrecioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(precio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrecioExists(precio.PrecioId))
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
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", precio.CursoId);
            return View(precio);
        }

        // GET: Precio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var precio = await _context.Precio
                .Include(p => p.Curso)
                .FirstOrDefaultAsync(m => m.PrecioId == id);
            if (precio == null)
            {
                return NotFound();
            }

            return View(precio);
        }

        // POST: Precio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var precio = await _context.Precio.FindAsync(id);
            _context.Precio.Remove(precio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrecioExists(int id)
        {
            return _context.Precio.Any(e => e.PrecioId == id);
        }
    }
}
