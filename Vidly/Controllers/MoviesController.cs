using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = GetMovies();
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieVieweModel
            {
                // Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek!"},
                new Movie { Id = 2, Name = "Wall-e!" },
                new Movie {Id = 3, Name = "Minions"},
                new Movie {Id = 4, Name = "Whatever"}
            };
        }

        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }

        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            string monthAlpha = "00" + month;
            string monthAlpha2 = monthAlpha.Substring(monthAlpha.Length - 2);
            return Content($"{year}/{monthAlpha2}");
        }
    }
}