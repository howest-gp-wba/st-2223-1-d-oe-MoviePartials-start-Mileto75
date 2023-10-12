using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Movies.Core;
using Wba.Oefening.Movies.Web.ViewModels;

namespace Wba.Oefening.Movies.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly DirectorRepository _directorRepository;
        private readonly ActorRepository _actorRepository;
        private readonly MovieRepository _movieRepository;

        public PeopleController()
        {
            _directorRepository = new DirectorRepository();
            _actorRepository = new ActorRepository();
            _movieRepository = new MovieRepository();
        }
        public IActionResult ShowDirectors()
        {
            var personsViewModel = new PersonsViewModel
            {
                Persons = _directorRepository
                .GetDirectors()
                .Select(d => new BasePersonViewModel
                {
                    Id = d.Id,
                    Firstname = d.FirstName,
                    Surname = d.SurName
                })
            };
            return View(personsViewModel);
        }

        public IActionResult ShowDirectorMovies(int id)
        {
            //get the movies where Directors property contains id
            
            var peopleShowDirectorMoviesViewModel = new PeopleShowDirectorMoviesViewModel();
            peopleShowDirectorMoviesViewModel.Movies = _movieRepository
                .GetMovies()
                .Where(m => m.Directors.Any(d => d.Id == id))
                .Select(m => new BaseViewModel
                { 
                    Id = m.Id,
                    Title = m.Title,
                    Image = m.Image
                });
            return View(peopleShowDirectorMoviesViewModel);
        }

        public IActionResult ShowActors()
        {
            var personsViewModel = new PersonsViewModel
            {
                Persons = _actorRepository
                .GetActors()
                .Select(d => new BasePersonViewModel
                {
                    Id = d.Id,
                    Firstname = d.FirstName,
                    Surname = d.SurName
                })
            };
            return View(personsViewModel);
        }
    }
}
