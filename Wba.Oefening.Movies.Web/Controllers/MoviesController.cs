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
    }
}
