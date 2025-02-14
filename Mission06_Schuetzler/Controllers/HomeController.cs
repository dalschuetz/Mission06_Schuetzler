using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    }
}
