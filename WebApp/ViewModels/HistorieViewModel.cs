using WebApp.Model;

namespace WebApp.Models
{
    public class HistorieViewModel
    {
        public List<HistorieModel> HistorieModels { get; set; }
        public HistorieSearchViewModel HistorieSearchViewModel { get; set; }

        public HistorieViewModel() { }

        public HistorieViewModel(List<HistorieModel> historieModel, HistorieSearchViewModel historieSearch)
        {
            
            HistorieSearchViewModel = historieSearch;
        }
    }
}
