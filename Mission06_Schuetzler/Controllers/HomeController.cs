using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Schuetzler.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Schuetzler.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext;

        public HomeController(MovieContext instance) 
        { 
            _movieContext = instance;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View(new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid) 
            {
                //saves form to database
                _movieContext.Movies.Add(response);
                _movieContext.SaveChanges();

                //reloads the form page to enter a new movie, no confirmation page
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(response);
            }
        }


        //pulling data from database into MovieList
        //NEED TO FIX CATEGORIES NOT SHOWING UP STILL
        public IActionResult MovieList()
        {
            var list = _movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(list);
        }


        //Edit Function
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editableMovie = _movieContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _movieContext.Categories.ToList();

            return View("MovieForm", editableMovie);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie) 
        {
            _movieContext.Update(updatedMovie);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        //Delete Function
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deleteableMovie = _movieContext.Movies
                .Single(x => x.MovieId == id);

            return View(deleteableMovie);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedMovie)
        {
            _movieContext.Remove(deletedMovie);
            _movieContext.SaveChanges();
            
            return RedirectToAction("MovieList");
        }
    }
}
