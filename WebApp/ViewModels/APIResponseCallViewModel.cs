using WebApp.Model;

namespace WebApp.Models
{
    public class APIResponseCallViewModel
    {
        public List<APIResponseCallModel> APIResponseCallModels { get; set; }
        public SearchViewModel SearchViewModel { get; set; }

        public APIResponseCallViewModel()
        {

        }

        public APIResponseCallViewModel(List<APIResponseCallModel> aPIResponseCallModels, SearchViewModel searchViewModel)
        {
            APIResponseCallModels = aPIResponseCallModels;
            SearchViewModel = searchViewModel;
        }
    }
}
