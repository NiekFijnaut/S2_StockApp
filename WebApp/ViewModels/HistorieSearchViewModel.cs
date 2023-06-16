using Microsoft.Build.Framework;

namespace WebApp.ViewModels
{
    public class HistorieSearchViewModel
    {
        [Required]
        public string Symbol { get; set; }

        [Required]
        public string Interval { get; set; }

        [Required]
        public string Slice { get; set; }

        public HistorieSearchViewModel()
        {

        }

        public HistorieSearchViewModel(string symbol, string interval, string slice)
        {
            Symbol = symbol;
            Interval = interval;
            Slice = slice;
        }
    }
}
