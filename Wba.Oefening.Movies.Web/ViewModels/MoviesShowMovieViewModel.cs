namespace Wba.Oefening.Movies.Web.ViewModels
{
    public class MoviesShowMovieViewModel : BaseViewModel
    {
        public BaseViewModel Genre { get; set; }
        public IEnumerable<BasePersonViewModel> Actors { get; set; }
        public IEnumerable<BasePersonViewModel> Directors { get; set; }
    }
}
