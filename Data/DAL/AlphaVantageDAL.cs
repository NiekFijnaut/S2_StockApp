using Interface;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class AlphaVantageDAL : IAlphaVantage
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

        public List<APIResponseCallDTO> GetAPIResponseCallList()
        {
            Sqlcon.Open();
            List<APIResponseCallDTO> apiResponseList = new List<APIResponseCallDTO>();
            using SqlCommand cmd6 = new("SELECT * FROM APIResponseCall WHERE Symbol = @Symbol", Sqlcon);
            using SqlDataReader reader6 = cmd6.ExecuteReader();
            while (reader6.Read())
            {
                apiResponseList.Add(
                    new APIResponseCallDTO(
                        null,
                        reader6.GetDateTime("Date"),
                        reader6.GetString("Symbol"),
                        reader6.GetDouble("Open"),
                        reader6.GetDouble("High"),
                        reader6.GetDouble("Low"),
                        reader6.GetDouble("Close"),
                        reader6.GetInt32("Volume")));
            }
            Sqlcon.Close();
            return apiResponseList;
        }
    }
}
