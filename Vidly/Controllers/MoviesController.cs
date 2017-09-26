using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie1 = new Movie() { Name = "Shrek" };
            var movie2 = new Movie() { Name = "Donkey" };
            var movie3 = new Movie() { Name = "Dragon" };
            var movie4 = new Movie() { Name = "Pussy" };
            //return View(movie);
            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home");
            //http://localhost:49719/?page=1&sortBy=name
            //return RedirectToAction("Index", "Home", new { page=1, sortBy="name"});

            ViewData["Movie"] = movie1;

            ViewBag.RandomMovie = movie2;
            //return View(movie3);


            var viewResult = new ViewResult();

            viewResult.ViewData.Model = movie4;
            viewResult.ViewData["Movie"] = movie1;
            viewResult.ViewBag.RandomMovie = movie2;
            
            return viewResult;
        }

        // GET: Movies/Rand
        public ActionResult Rand()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer() {Name="Customer1"},
                new Customer() { Name="Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            //http://localhost:49719/movies/edit/2
            //http://localhost:49719/movies/edit?id=3
            return Content("Id:"+ id);
        }

        public ActionResult EditAnother(int movieId)
        {
            //http://localhost:49719/movies/editanother/2   It doesn't work. Because RouteConfig.cs "{controller}/{action}/{id}",
            //http://localhost:49719/movies/editanother?movieId=2 works
            return Content("Id:" + movieId);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    //http://localhost:49719/movies  >> pageIndex=1&sortBy=Name
        //    //http://localhost:49719/movies?pageIndex=2  >> pageIndex=2&sortBy=Name
        //   // http://localhost:49719/movies?pageIndex=2&sortBy=ReleaseDate  >> pageIndex=2&sortBy=ReleaseDate
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));
        //}


        public ViewResult Index()
        {
            //var movies = _context.Movies; //defered execution of query
            var movies = _context.Movies; //immediate execution of query

            return View(movies);
        }

        //private IEnumerable<Movie> GetMovies()
        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id =1, Name = "Shrek"},
                new Movie { Name = "Wall-e"}
            };
        }

        //AST.net MVC Attribute Route Constraints google for tips
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            /// http://localhost:49719/movies/released Doesn't much anything
            //http://localhost:49719/movies/released/2015/4   >> It doesn't work anymore Because of constraint on Month
            //http://localhost:49719/movies/released/2015/04 >> 2015/4
            //http://localhost:49719/movies/released/2015/23  >>404 error
            return Content(year + "/" + month);
        }
    }
}
