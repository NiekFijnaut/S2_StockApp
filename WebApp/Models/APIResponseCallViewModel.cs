using Business;

namespace WebApp.Models
{
    public class APIResponseCallViewModel
    {
        public List<APIResponseCall> APIResponselist { get; set; }
        public SearchViewModel SearchViewModel { get; set; }

        public APIResponseCallViewModel()
        {

        }

        public APIResponseCallViewModel(List<APIResponseCall> aPIResponselist, SearchViewModel searchViewModel)
        {
            APIResponselist = aPIResponselist;
            SearchViewModel = searchViewModel;
        }
    }
}
