namespace WebApp.ViewModels
{
    public class HistorieViewModelList
    {
        public List<HistorieViewModel> HistorieModels { get; set; }
        public HistorieSearchViewModel HistorieSearchViewModel { get; set; }

        public HistorieViewModelList() { }

        public HistorieViewModelList(List<HistorieViewModel> historieModel, HistorieSearchViewModel historieSearch)
        {
            
            HistorieSearchViewModel = historieSearch;
        }
    }
}
