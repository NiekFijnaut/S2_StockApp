using CsvHelper;
using Interface;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Serilog;
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

        const string APIKEY = "ZN0C9Q4C0LG3REEE";

        const string BaseUrl = "https://www.alphavantage.co/query";

        public async Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO)
        {
            try
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

                string ApiFunction = "TIME_SERIES_INTRADAY";
// ik heb ervoor gekozen geen extra validatie op symbol te zetten omdat het niet te achter halen is ofdat er een juist symbool is ingevoerd,
// vanwege de return van de api die een eroor geeft die niet speciefiek genoeg is. de method faalt en de gebruiker krijgt de error van de catch te zien.
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
            catch (Exception ex)
            {
                Log.Error(ex, "Search stock intel failed");
                return new List<APIResponseCallDTO>();
            }
        }


        public async Task<List<HistorieDTO>> SearchHistorieStock(SearchDTO searchDTO)
        {
            try
            {
                string searchquery = "INSERT INTO SearchStock (Symbol, Interval, Slice) VALUES (@Symbol, @Interval, @Slice)";

                using (SqlCommand searchcmd = new SqlCommand(searchquery, Sqlcon))
                {
                    Sqlcon.Open();
                    searchcmd.Parameters.AddWithValue("@Symbol", searchDTO.Symbol);
                    searchcmd.Parameters.AddWithValue("@Interval", searchDTO.Interval);
                    searchcmd.Parameters.AddWithValue("@Slice", searchDTO.Slice);

                    searchcmd.ExecuteNonQuery();
                    Sqlcon.Close();
                }

                string symbol = searchDTO.Symbol;

                string Interval = searchDTO.Interval;

                string slice = searchDTO.Slice;

                string ApiFunction = "TIME_SERIES_INTRADAY_EXTENDED";

                string apiurl = $"{BaseUrl}?function={ApiFunction}&symbol={symbol}&interval={Interval}&slice={slice}&apikey={APIKEY}";

                Uri queryUri = new Uri(apiurl);

                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                List<HistorieDTO> historielist = new List<HistorieDTO>(); 

                using (HttpClient client = new HttpClient())
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        using (Stream stream = await client.GetStreamAsync(queryUri))
                        {
                            await stream.CopyToAsync(memStream);
                        }
                        
                        memStream.Position = 0;

                        using (StreamReader reader = new StreamReader(memStream))
                        {
                            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                            {
                                csv.Read();
                                csv.ReadHeader();

                                while (csv.Read())
                                {
                                    DateTime time = DateTime.Parse(csv.GetField<string>("time"));
                                    double open = Math.Round(csv.GetField<double>("open"), 2);
                                    double high = Math.Round(csv.GetField<double>("high"), 2);
                                    double low = Math.Round(csv.GetField<double>("low"), 2);
                                    double close = Math.Round(csv.GetField<double>("close"), 2);
                                    int volume = csv.GetField<int>("volume");

                                    HistorieDTO history = new HistorieDTO(
                                        null,
                                        time,
                                        symbol,
                                        open,
                                        high,
                                        low,
                                        close,
                                        volume
                                    );

                                    historielist.Add(history);
                                }
                            }
                        }
                    }
                }
                return historielist;
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Search histroy intel failed");
                return new List<HistorieDTO>();
            }
        }
    }
}
