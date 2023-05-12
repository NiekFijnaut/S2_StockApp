using Business;
using Microsoft.Build.Framework;

namespace WebApp
{
    public class SearchModel
    {
        [Required]
        public string Symbol { get; set; }
        
        [Required]
        public string Interval { get; set; }

         
        public SearchModel(string symbol, string interval)
        {
            Symbol = symbol;
            Interval = interval;
        }
    }
}
