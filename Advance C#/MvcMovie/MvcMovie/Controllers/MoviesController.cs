using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // L'index de la méthode d’action Index est une méthode asynchrone qui retourne une Task<IActionResult>. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP pour l’URL /Movies.
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // La méthode d’action Index utilise la méthode AsNoTracking pour améliorer les performances en désactivant le suivi des entités
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            // On fqit une requête pour obtenir la liste de tous les genres de films
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            // La méthode d’action Index filtre les films en fonction de la chaîne de recherche fournie par l’utilisateur
            {
                // on fait une requête pour obtenir les films qui contiennent la chaîne de recherche
                movies = movies.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                // La méthode d’action Index filtre les films en fonction du genre sélectionné par l’utilisateur
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                // La méthode d’action Index crée un objet MovieGenreViewModel et l’initialise avec la liste des genres de films et la liste des films
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };
            // La méthode d’action Index passe le modèle de vue à la vue Index
            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        // La méthode d’action Details est une méthode asynchrone qui retourne une Task<IActionResult>. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP pour l’URL /Movies/Details/{id}.
        {
            if (id == null)
            {
                return NotFound();
            }

            // La méthode d’action Details utilise la méthode FirstOrDefaultAsync pour obtenir les détails d’un film à partir de l’ID fourni dans la requête
            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        // La méthode d’action Create est une méthode synchrone qui retourne une vue. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP pour l’URL /Movies/Create.
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        // La méthode d’action Create est une méthode asynchrone qui retourne une Task<IActionResult>. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP POST pour l’URL /Movies/Create.
        {
            if (ModelState.IsValid)
            {
                // La méthode d’action Create ajoute un film à la base de données et redirige l’utilisateur vers la vue Index
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        // La méthode d’action Edit est une méthode asynchrone qui retourne une Task<IActionResult>. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP pour l’URL /Movies/Edit/{id}.
        {
            if (id == null)
            {
                return NotFound();
            }

            // La méthode d’action Edit utilise la méthode FindAsync pour obtenir les détails d’un film à partir de l’ID fourni dans la requête
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // L’attribut ValidateAntiForgeryToken est utilisé pour lutter contre la falsification d’une requête. Il est associé à un jeton anti-falsification généré dans le fichier de la vue de modification (Views/Movies/Edit.cshtml). Le fichier de la vue de modification génère le jeton anti-falsification avec le Form Tag Helper.
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        // La méthode d’action Edit est une méthode asynchrone qui retourne une Task<IActionResult>. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP POST pour l’URL /Movies/Edit/{id}.
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // La méthode d’action Edit met à jour un film dans la base de données et redirige l’utilisateur vers la vue Index
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        // La méthode d’action Delete est une méthode asynchrone qui retourne une Task<IActionResult>. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP pour l’URL /Movies/Delete/{id}.
        {
            if (id == null)
            {
                return NotFound();
            }

            // La méthode d’action Delete utilise la méthode FindAsync pour obtenir les détails d’un film à partir de l’ID fourni dans la requête
            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        // La méthode d’action DeleteConfirmed est une méthode asynchrone qui retourne une Task<IActionResult>. Elle est appelée par le framework MVC pour répondre aux requêtes HTTP POST pour l’URL /Movies/Delete/{id}.
        {
            // La méthode d’action DeleteConfirmed supprime un film de la base de données et redirige l’utilisateur vers la vue Index
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            // La méthode SaveChangesAsync enregistre les modifications apportées à la base de données
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            // La méthode MovieExists vérifie si un film existe dans la base de données
            return _context.Movie.Any(e => e.Id == id);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
