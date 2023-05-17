using Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class AlphaVantageDAL : IALphaVantage
    {
        SqlConnection Sqlcon = DataString.connection;
        public async Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO)
        {            
            string searchquery = "INSERT INTO SearchStock (Symbol, Interval) VALUES (@Symbol, @Interval)";
            
            using (SqlCommand searchcmd = new SqlCommand(searchquery, Sqlcon))
            {
                Sqlcon.Open();
                searchcmd.Parameters.AddWithValue("@Symbol", searchDTO.Symbol);
                searchcmd.Parameters.AddWithValue("@Interval", searchDTO.Interval);

                searchcmd.ExecuteNonQuery();
                Sqlcon.Close();
            }

            string Symbol = searchDTO.Symbol;

            string Interval = searchDTO.Interval;

            const string APIKEY = "ZN0C9Q4C0LG3REEE";

            const string BaseUrl = "https://www.alphavantage.co/query";

            string ApiFunction = "TIME_SERIES_INTRADAY";

            string apiurl = $"{BaseUrl}?function={ApiFunction}&symbol={Symbol}&interval={Interval}&apikey={APIKEY}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiurl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(json);

                    string symbolName = data?["Meta Data"]?["2. Symbol"]?.ToString();
                    //string lastRefreshed = data?["Meta Data"]?["3. Last Refreshed"]?.ToString();
                    //string interval = data?["Meta Data"]?["4. Interval"]?.ToString();
                    //string info = data?["Meta Data"]?["1. Information"]?.ToString();

                    var timeSeries = data?["Time Series " + "(" + Interval + ")"];
                    if (timeSeries != null)
                    {

                        List<APIResponseCallDTO> ApiResponse = new List<APIResponseCallDTO>();
                        foreach (JProperty property in timeSeries.Children<JProperty>())
                        {
                            DateTime date = DateTime.Parse(property.Name);
                            double open = double.Parse(property.Value["1. open"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double high = double.Parse(property.Value["2. high"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double low = double.Parse(property.Value["3. low"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double close = double.Parse(property.Value["4. close"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            int volume = int.Parse(property.Value["5. volume"].ToString());

                            // hier wordt de klasse aangevuld met de gevraagde info
                            
                            APIResponseCallDTO aPIResponseCallDTO = new APIResponseCallDTO
                            (
                                null,
                                date,
                                symbolName,
                                open,
                                high,
                                low,
                                close,
                                volume
                            );
                            ApiResponse.Add(aPIResponseCallDTO);
                        }
                        return ApiResponse;
                    }
                }
            }
            return new List<APIResponseCallDTO>();

            
        }

        public async void AddStockToAccount(string Symbol, string ddlInterval)
        {
            const string APIKEY = "ZN0C9Q4C0LG3REEE";

            const string BaseUrl = "https://www.alphavantage.co/query";

            string ApiFunction = "TIME_SERIES_INTRADAY";

            string apiurl = $"{BaseUrl}?function={ApiFunction}&symbol={Symbol}&interval={ddlInterval}&apikey={APIKEY}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiurl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(json);

                    string symbolName = data?["Meta Data"]?["2. Symbol"]?.ToString();
                    //string lastRefreshed = data?["Meta Data"]?["3. Last Refreshed"]?.ToString();
                    //string interval = data?["Meta Data"]?["4. Interval"]?.ToString();
                    //string info = data?["Meta Data"]?["1. Information"]?.ToString();

                    var timeSeries = data?["Time Series " + "(" + ddlInterval + ")"];
                    if (timeSeries != null)
                    {

                        foreach (JProperty property in timeSeries.Children<JProperty>())
                        {
                            DateTime date = DateTime.Parse(property.Name);
                            double open = double.Parse(property.Value["1. open"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double high = double.Parse(property.Value["2. high"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double low = double.Parse(property.Value["3. low"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double close = double.Parse(property.Value["4. close"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            int volume = int.Parse(property.Value["5. volume"].ToString());

                        }
                    }
                }
            }
        }
    }
}
