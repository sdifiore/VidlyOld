using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = _context.Movies.Include(m => m.Genre);
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var viewModel = new RandomMovieVieweModel
            {
                //Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            string monthAlpha = "00" + month;
            string monthAlpha2 = monthAlpha.Substring(monthAlpha.Length - 2);
            return Content($"{year}/{monthAlpha2}");
        }

        public ViewResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }
    }
}