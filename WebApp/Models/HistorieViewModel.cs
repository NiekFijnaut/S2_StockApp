using Business;

namespace WebApp.Models
{
    public class HistorieViewModel
    {
        public List<Historie> Histories { get; set; }

        public HistorieSearchViewModel HistorieSearchViewModel { get; set; }

        public HistorieViewModel(List<Historie> histories, HistorieSearchViewModel historieSearch)
        {
            Histories = histories;
            HistorieSearchViewModel = historieSearch;
        }
    }
}
