namespace Wba.Oefening.Movies.Web.ViewModels
{
    public class MoviesIndexViewModel
    {
        public IEnumerable<BaseViewModel> Movies { get; set; }
        public string PageTitle { get; set; }
    }
}
