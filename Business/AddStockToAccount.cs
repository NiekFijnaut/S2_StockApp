using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business
{
    public class AddStockToAccount
    {
        
        public static void Main(string[] args)
        {
            string Ticker = "AAPL";
            string APIKEY = "ZN0C9Q4C0LG3REEE";

            string QUERY_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=" + Ticker + "&apikey=" + APIKEY;
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                dynamic json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

            }
        }
    }
}
