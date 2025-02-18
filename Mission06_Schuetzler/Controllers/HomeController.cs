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

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            //saves form to database
            _movieContext.Movies.Add(response);
            _movieContext.SaveChanges();

            //reloads the form page to enter a new movie, no confirmation page
            return RedirectToAction("MovieForm");
        }

        //pulling data from database into MovieList
        public IActionResult MovieList()
        {
            var list = _movieContext.Movies
                //.Include(x => x.Categories)
                .OrderBy(x => x.Title).ToList();
                

            return View(list);
        }

        [HttpGet]
        public IActionResult UpdateMovie()
        {
            return RedirectToAction("MovieForm");
        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie response) 
        {
            return RedirectToAction("MovieList");
        }
    }
}
