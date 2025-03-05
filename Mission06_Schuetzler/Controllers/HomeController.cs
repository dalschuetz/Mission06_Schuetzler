using System.Diagnostics; // Debugging
using AspNetCoreGeneratedDocument; // Razor Code (Auto-generated documentation)
using Microsoft.AspNetCore.Mvc; // Controllers, Actions
using Microsoft.EntityFrameworkCore; // Entity Framework
using Mission06_Schuetzler.Models; // Models
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Schuetzler.Controllers // MVC Pattern (Controllers)
{
    public class HomeController : Controller // Controllers
    {
        private MovieContext _movieContext; // DbContext

        public HomeController(MovieContext instance)  // Constructor
        {
            _movieContext = instance;
        }

        public IActionResult Index() // Action
        {
            return View(); // Views
        }

        public IActionResult GetToKnow() // Action
        {
            return View(); // Views
        }

        [HttpGet] // HTTP Method (Get)
        public IActionResult MovieForm() // Action
        {
            ViewBag.Categories = _movieContext.Categories.ToList(); // Linq, DbSet, IQueryable, List

            return View(new Movie()); // Views, Models
        }

        [HttpPost] // HTTP Method (Post)
        public IActionResult MovieForm(Movie response) // Action, Model Binding
        {
            if (ModelState.IsValid)  // ModelState.IsValid, Data Annotations
            {
                // Saves form to database
                _movieContext.Movies.Add(response); // DbSet, Entity Framework
                _movieContext.SaveChanges(); // Entity Framework

                // Reloads the form page to enter a new movie, no confirmation page
                return RedirectToAction("MovieList"); // Navigation (Routing) in MVC
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList(); // Linq, DbSet, IQueryable, List

                return View(response); // Views
            }
        }

        // Pulling data from database into MovieList
        // NEED TO FIX CATEGORIES NOT SHOWING UP STILL
        public IActionResult MovieList() // Action
        {
            var list = _movieContext.Movies // DbSet, IQueryable
                .Include(x => x.Category) // Entity Framework (Relationships)
                .OrderBy(x => x.Title) // Linq
                .ToList(); // List

            return View(list); // Views
        }

        // Edit Function
        [HttpGet] // HTTP Method (Get)
        public IActionResult Edit(int id) // Action
        {
            var editableMovie = _movieContext.Movies // DbSet, IQueryable
                .Single(x => x.MovieId == id); // Linq

            ViewBag.Categories = _movieContext.Categories.ToList(); // Linq, DbSet, IQueryable, List

            return View("MovieForm", editableMovie); // Views, Model Binding
        }

        [HttpPost] // HTTP Method (Post)
        public IActionResult Edit(Movie updatedMovie)  // Action, Model Binding
        {
            _movieContext.Update(updatedMovie); // Entity Framework
            _movieContext.SaveChanges(); // Entity Framework

            return RedirectToAction("MovieList"); // Navigation (Routing) in MVC
        }

        // Delete Function
        [HttpGet] // HTTP Method (Get)
        public IActionResult Delete(int id) // Action
        {
            var deleteableMovie = _movieContext.Movies // DbSet, IQueryable
                .Single(x => x.MovieId == id); // Linq

            return View(deleteableMovie); // Views, Model Binding
        }

        [HttpPost] // HTTP Method (Post)
        public IActionResult Delete(Movie deletedMovie) // Action, Model Binding
        {
            _movieContext.Remove(deletedMovie); // Entity Framework
            _movieContext.SaveChanges(); // Entity Framework

            return RedirectToAction("MovieList"); // Navigation (Routing) in MVC
        }
    }
}
