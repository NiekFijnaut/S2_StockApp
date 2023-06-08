using CsvHelper;
using Interface;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HistorieDAL : IHistorie
    {
        SqlConnection Sqlcon = DataString.connection;

        public async Task<List<HistorieDTO>> SearchHistorieStock(SearchDTO searchDTO)
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

            const string APIKEY = "ZN0C9Q4C0LG3REEE";

            const string BaseUrl = "https://www.alphavantage.co/query";
           
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
        public void AddHistorie(HistorieDTO historieDTO)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Historie (HistorieID, Date, Symbol, Open, High, Low, Close, Volume) VALUES (@HistorieID, @Date, @Symbol, @Open, @High, @Low, @Close, @Volume)", Sqlcon))
            {

                cmd.Parameters.AddWithValue("@Date", historieDTO.Date);
                cmd.Parameters.AddWithValue("@Symbol", historieDTO.Symbol);
                cmd.Parameters.AddWithValue("@Open", historieDTO.Open);
                cmd.Parameters.AddWithValue("@High", historieDTO.High);
                cmd.Parameters.AddWithValue("@Low", historieDTO.Low);
                cmd.Parameters.AddWithValue("@Close", historieDTO.Close);
                cmd.Parameters.AddWithValue("@Volume", historieDTO.Volume);

                Sqlcon.Open();
                cmd.ExecuteNonQuery();

            }

        }

        public List<HistorieDTO> ViewHistorie(HistorieDTO historieDTO)
        {
            List<HistorieDTO> Historielist = new List<HistorieDTO>();
            using (SqlCommand cmd1 = new SqlCommand("SELECT Date, Symbol, Open, High, Low, Close, Volume FROM Historie", Sqlcon))
            {
                Sqlcon.Open();
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //HistorieDTO historie = new HistorieDTO();
                        //historie.Date = (DateTime)reader["Date"];
                        //historie.Symbol = (string)reader["Symbol"];
                        //historie.Open = (decimal)reader["Open"];
                        //historie.High = (decimal)reader["High"];
                        //historie.Low = (decimal)reader["Low"];
                        //historie.Close = (decimal)reader["Close"];
                        //historie.Volume = (int)reader["Volume"];

                        //Historielist.Add(historie);
                    }
                }
            }
            return Historielist;
        }

    }
}
