using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTIC.Data;
using PruebaTIC.Models;

namespace PruebaTIC.Controllers
{
    public class PersonasController : Controller
    {
        private readonly PersonasContext _context;

        public PersonasController(PersonasContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,Foto")] Personas personas)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(personas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personas);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas.FindAsync(id);
            if (personas == null)
            {
                return NotFound();
            }
            return View(personas);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,Foto")] Personas personas)
        {
            if (id != personas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasExists(personas.Id))
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
            return View(personas);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personas = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
