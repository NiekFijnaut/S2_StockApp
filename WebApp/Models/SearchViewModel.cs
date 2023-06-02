using Business;
using Microsoft.Build.Framework;

namespace WebApp
{
    public class SearchViewModel
    {
        [Required]
        public string Symbol { get; set; }
        
        [Required]
        public string Interval { get; set; }

        public SearchViewModel()
        {

        }

        public SearchViewModel(string symbol, string interval)
        {
            Symbol = symbol;
            Interval = interval;
        }
    }
}
