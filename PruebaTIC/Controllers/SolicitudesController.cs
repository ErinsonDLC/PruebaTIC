using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTIC.Data;
using PruebaTIC.Models;

namespace PruebaTIC.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly SolicitudesContext _context;

        public SolicitudesController(SolicitudesContext context)
        {
            _context = context;
        }

        // GET: Solicitudes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Solicitudes.ToListAsync());
        }

        // GET: Solicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudes = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            return View(solicitudes);
        }

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreEstado,FechaCreacion")] Solicitudes solicitudes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitudes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitudes);
        }

        // GET: Solicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudes = await _context.Solicitudes.FindAsync(id);
            if (solicitudes == null)
            {
                return NotFound();
            }
            return View(solicitudes);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreEstado,FechaCreacion")] Solicitudes solicitudes)
        {
            if (id != solicitudes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitudes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudesExists(solicitudes.Id))
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
            return View(solicitudes);
        }

        // GET: Solicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudes = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            return View(solicitudes);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitudes = await _context.Solicitudes.FindAsync(id);
            _context.Solicitudes.Remove(solicitudes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudesExists(int id)
        {
            return _context.Solicitudes.Any(e => e.Id == id);
        }
    }
}
