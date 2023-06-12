using CsvHelper;
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
            catch
            {
                throw new Exception("StockIntel cannot be received");
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
                List<HistorieDTO> historielist = new List<HistorieDTO>(); // List to store the historical data

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
                                    DateTime date = DateTime.Parse(csv.GetField<string>("Date"));
                                    double open = csv.GetField<double>("Open");
                                    double high = csv.GetField<double>("High");
                                    double low = csv.GetField<double>("Low");
                                    double close = csv.GetField<double>("Close");
                                    int volume = csv.GetField<int>("Volume");

                                    HistorieDTO history = new HistorieDTO(
                                        null,
                                        date,
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
            catch
            {
                throw new Exception("History Intel cannot be received");
            }
        }
    }
}
