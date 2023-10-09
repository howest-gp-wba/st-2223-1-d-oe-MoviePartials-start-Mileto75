using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Core;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieRepository _movieRepository;

        public MoviesController()
        {
            _movieRepository = new MovieRepository();
        }
        public IActionResult Index()
        {
            //get the data
            var movies = _movieRepository
                .GetMovies();
            //fill the model
            var moviesIndexViewModel
                = new MoviesIndexViewModel
                {
                    Movies =
                    movies.Select(m => new BaseViewModel
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Image = m.Image
                    })
                };
            //pass tot the view
            moviesIndexViewModel.PageTitle = "Our Movies";
            return View(moviesIndexViewModel);
        }
        public IActionResult ShowMovie(long movieId)
        {
            //get the movie using id
            var movie = _movieRepository
                .GetMovies().FirstOrDefault
                (m => m.Id == movieId);
            //check for null
            if (movie == null)
            {
                return NotFound();
            }
            //fill the model
            var moviesShowMovieViewModel
                = new MoviesShowMovieViewModel
                {
                    Title = movie.Title,
                    Image = movie.Image,
                    Genre = new BaseViewModel
                    {
                        Id = movie.Genre.Id,
                        Title = movie.Genre.Name,
                    },
                    Actors = movie.Actors
                    .Select(a => new BasePersonViewModel
                    {
                        Id = a.Id,
                        Firstname = a.FirstName,
                        Surname = a.SurName,
                    }),
                    Directors = movie.Directors
                    .Select(d => new BasePersonViewModel
                    {
                        Id = d.Id,
                        Firstname= d.FirstName,
                        Surname = d.SurName,
                    }),
                };
            //pass to the view
            return View(moviesShowMovieViewModel);
        }
    }
}
