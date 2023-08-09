namespace WebApp.ViewModels
{
    public class APIResponseCallViewModelList
    {
        public List<APIResponseCallViewModel> APIResponseCallModels { get; set; }
        public SearchViewModel SearchViewModel { get; set; }

        public APIResponseCallViewModelList()
        {

        }

        public APIResponseCallViewModelList(List<APIResponseCallViewModel> aPIResponseCallModels, SearchViewModel searchViewModel)
        {
            APIResponseCallModels = aPIResponseCallModels;
            SearchViewModel = searchViewModel;
        }
    }
}
