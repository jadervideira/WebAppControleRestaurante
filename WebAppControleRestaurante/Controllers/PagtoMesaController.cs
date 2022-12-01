using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppControleRestaurante.Data;
using WebAppControleRestaurante.Models;

namespace WebAppControleRestaurante.Controllers
{
    public class PagtoMesaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagtoMesaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PagtoMesaModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.PagtoMesaModel.ToListAsync());
        }

        // GET: PagtoMesaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PagtoMesaModel == null)
            {
                return NotFound();
            }

            var pagtoMesaModel = await _context.PagtoMesaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagtoMesaModel == null)
            {
                return NotFound();
            }

            return View(pagtoMesaModel);
        }

        // GET: PagtoMesaModels/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagtoMesaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,NumMesa,ValConsumo")] PagtoMesaModel pagtoMesaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagtoMesaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagtoMesaModel);
        }

        // GET: PagtoMesaModels/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PagtoMesaModel == null)
            {
                return NotFound();
            }

            var pagtoMesaModel = await _context.PagtoMesaModel.FindAsync(id);
            if (pagtoMesaModel == null)
            {
                return NotFound();
            }
            return View(pagtoMesaModel);
        }

        // POST: PagtoMesaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,NumMesa,ValConsumo")] PagtoMesaModel pagtoMesaModel)
        {
            if (id != pagtoMesaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagtoMesaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagtoMesaModelExists(pagtoMesaModel.Id))
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
            return View(pagtoMesaModel);
        }

        // GET: PagtoMesaModels/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PagtoMesaModel == null)
            {
                return NotFound();
            }

            var pagtoMesaModel = await _context.PagtoMesaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagtoMesaModel == null)
            {
                return NotFound();
            }

            return View(pagtoMesaModel);
        }

        // POST: PagtoMesaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PagtoMesaModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PagtoMesaModel'  is null.");
            }
            var pagtoMesaModel = await _context.PagtoMesaModel.FindAsync(id);
            if (pagtoMesaModel != null)
            {
                _context.PagtoMesaModel.Remove(pagtoMesaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagtoMesaModelExists(int id)
        {
          return _context.PagtoMesaModel.Any(e => e.Id == id);
        }
    }
}
