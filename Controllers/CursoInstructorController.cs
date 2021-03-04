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
    public class CursoInstructorController : Controller
    {
        private readonly ContextoCursos _context;

        public CursoInstructorController(ContextoCursos context)
        {
            _context = context;
        }

        // GET: CursoInstructor
        public async Task<IActionResult> Index()
        {
            var contextoCursos = _context.CursoInstructor.Include(c => c.Curso).Include(c => c.Instructor);
            return View(await contextoCursos.ToListAsync());
        }

        // GET: CursoInstructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoInstructor = await _context.CursoInstructor
                .Include(c => c.Curso)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoInstructor == null)
            {
                return NotFound();
            }

            return View(cursoInstructor);
        }

        // GET: CursoInstructor/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId");
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId");
            return View();
        }

        // POST: CursoInstructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,CursoId")] CursoInstructor cursoInstructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoInstructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", cursoInstructor.CursoId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId", cursoInstructor.InstructorId);
            return View(cursoInstructor);
        }

        // GET: CursoInstructor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoInstructor = await _context.CursoInstructor.FindAsync(id);
            if (cursoInstructor == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", cursoInstructor.CursoId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId", cursoInstructor.InstructorId);
            return View(cursoInstructor);
        }

        // POST: CursoInstructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,CursoId")] CursoInstructor cursoInstructor)
        {
            if (id != cursoInstructor.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoInstructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoInstructorExists(cursoInstructor.CursoId))
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
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", cursoInstructor.CursoId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId", cursoInstructor.InstructorId);
            return View(cursoInstructor);
        }

        // GET: CursoInstructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoInstructor = await _context.CursoInstructor
                .Include(c => c.Curso)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoInstructor == null)
            {
                return NotFound();
            }

            return View(cursoInstructor);
        }

        // POST: CursoInstructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoInstructor = await _context.CursoInstructor.FindAsync(id);
            _context.CursoInstructor.Remove(cursoInstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoInstructorExists(int id)
        {
            return _context.CursoInstructor.Any(e => e.CursoId == id);
        }
    }
}
