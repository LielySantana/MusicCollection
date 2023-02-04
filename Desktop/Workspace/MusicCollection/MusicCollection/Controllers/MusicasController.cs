using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicCollection.Data;
using MusicCollection.Models;

namespace MusicCollection.Controllers
{
    public class MusicasController : Controller
    {
        private readonly MusicCollectionContext _context;

        public MusicasController(MusicCollectionContext context)
        {
            _context = context;
        }

        // GET: Musicas
        public async Task<IActionResult> Index(string busqueda,int? FiltroGenero )
        {
            var musicCollectionContext = from t in _context.Musica.Include(m => m.Genero)
                                         select t;
            var generos = new SelectList(_context.Generos, "Id", "Nombre");

            if (!String.IsNullOrEmpty(busqueda))
            {
                musicCollectionContext = musicCollectionContext.Where(n => n.Artista.Contains(busqueda));
            }

            if(FiltroGenero != null)
            {
                musicCollectionContext = musicCollectionContext.Where(n => n.GeneroId == FiltroGenero);
            }

            var musicaVM = new MusicaViewModel
            {
                Musica = await musicCollectionContext.ToListAsync(),
                ListaGeneros = generos
            };
            return View(musicaVM);
        }

        // GET: Musicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica
                .Include(m => m.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        // GET: Musicas/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nombre");
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Artista,Titulo,Ano,Formato,GeneroId")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id", musica.GeneroId);
            return View(musica);
        }

        // GET: Musicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica.FindAsync(id);
            if (musica == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Nombre", musica.GeneroId);
            return View(musica);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Artista,Titulo,Ano,Formato,GeneroId")] Musica musica)
        {
            if (id != musica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicaExists(musica.Id))
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
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Id", musica.GeneroId);
            return View(musica);
        }

        // GET: Musicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica
                .Include(m => m.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Musica == null)
            {
                return Problem("Entity set 'MusicCollectionContext.Musica'  is null.");
            }
            var musica = await _context.Musica.FindAsync(id);
            if (musica != null)
            {
                _context.Musica.Remove(musica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Resumen()
        {
            // busco todos los generos
            var generos = await _context.Generos.ToListAsync();
            if(generos.Count == 0)
            {
                return NotFound();
            }

            List<ResumenViewModel> resumen = new List<ResumenViewModel>();

            foreach(var genero in generos)
            {
                var cantidad = _context.Musica.
                                Where(g => g.GeneroId == genero.Id)
                                .Count();

                resumen.Add(new ResumenViewModel
                {
                    Genero = genero.Descripcion,
                    Cantidad = cantidad
                });
            }

            return View(resumen); 
        }
        private bool MusicaExists(int id)
        {
            return (_context.Musica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
