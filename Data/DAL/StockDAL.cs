using CsvHelper.Configuration.Attributes;
using Interface;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Data
{
    public class StockDAL : IStock, IAlphaVantage
    {
        SqlConnection Sqlcon = DataString.connection;
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 
        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, AccountStockDTO accountStockDTO)
        {
            string apiinsertquery = "INSERT INTO APIResponseCall (Date, Symbol, [Open], High, Low, [Close], Volume) VALUES (@Date, @Symbol, @Open, @High, @Low, @Close, @Volume)";
            using (SqlCommand apiinsertCmd = new SqlCommand(apiinsertquery, Sqlcon))
            {
                Sqlcon.Open();
                apiinsertCmd.Parameters.AddWithValue("@Date", aPIResponseCallDTO.Date);
                apiinsertCmd.Parameters.AddWithValue("@Symbol", aPIResponseCallDTO.Symbol);
                apiinsertCmd.Parameters.AddWithValue("@Open", aPIResponseCallDTO.Open);
                apiinsertCmd.Parameters.AddWithValue("@High", aPIResponseCallDTO.High);
                apiinsertCmd.Parameters.AddWithValue("@Low", aPIResponseCallDTO.Low);
                apiinsertCmd.Parameters.AddWithValue("@Close", aPIResponseCallDTO.Close);
                apiinsertCmd.Parameters.AddWithValue("@Volume", aPIResponseCallDTO.Volume);

                apiinsertCmd.ExecuteNonQuery();
                Sqlcon.Close();
            }

            // Retrieve the newly inserted StockID from the APIResponseCall table
            int stockID;
            using (SqlCommand getStockIDCmd = new SqlCommand("SELECT IDENT_CURRENT('APIResponseCall')", Sqlcon))
            {
                Sqlcon.Open();
                stockID = Convert.ToInt32(getStockIDCmd.ExecuteScalar());
                Sqlcon.Close();
            }

            string insertQuery = 
                @"IF NOT EXISTS (SELECT 1 FROM AccountStock WHERE Symbol = @Symbol) 
                BEGIN INSERT INTO AccountStock (StockID, Date, Symbol) SELECT TOP 1 @StockID, @Date, @Symbol FROM APIResponseCall ORDER BY Date DESC END";
            using (SqlCommand cmd5 = new SqlCommand(insertQuery, Sqlcon))
            {
                cmd5.Parameters.AddWithValue("@StockID", stockID);
                cmd5.Parameters.AddWithValue("@Date", aPIResponseCallDTO.Date);
                cmd5.Parameters.AddWithValue("@Symbol", aPIResponseCallDTO.Symbol);


                Sqlcon.Open();
                cmd5.ExecuteNonQuery();
                Sqlcon.Close();
            }
        }

       

        public List<AccountStockDTO> GetAccountStockList()
        {
            Sqlcon.Open();
            List<AccountStockDTO> accountStockList = new();
            using SqlCommand cmd1 = new("SELECT Date, Symbol FROM [dbo].[AccountStock]", Sqlcon);
            using SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                accountStockList.Add(
                new AccountStockDTO(
                    null,
                    reader1.GetDateTime("Date"),
                    reader1.GetString("Symbol"),
                    null));
            }
            Sqlcon.Close();
            return accountStockList;
        }

        public void UpdateStockTable(APIResponseCallDTO aPIResponseCallDTO)
        {
            string updateQuery = "UPDATE stock SET Date = @Date WHERE Symbol = @Symbol";
            SqlCommand cmd2 = new SqlCommand(updateQuery, Sqlcon);
            cmd2.Parameters.AddWithValue("@Symbol", aPIResponseCallDTO.Symbol);
            cmd2.Parameters.AddWithValue("@Date", aPIResponseCallDTO.Date);
            int rowsAffected = cmd2.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                string insrtQuery = "INSERT INTO AccountStock (Date, Symbol) VALUES (@Date, @Symbol)";
                SqlCommand cmd3 = new SqlCommand(insrtQuery, Sqlcon);
                cmd3.Parameters.AddWithValue("@Symbol", aPIResponseCallDTO.Symbol);
                cmd3.Parameters.AddWithValue("@Date", aPIResponseCallDTO.Date);
                cmd3.ExecuteNonQuery();
            }
        }

        public void DeleteStock(string symbol)
        {
            string deletequery = "DELETE FROM AccountStock WHERE Symbol = @Symbol";
            SqlCommand cmd4 = new SqlCommand(deletequery, Sqlcon);
            cmd4.ExecuteNonQuery();
        }

        public Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO)
        {
            throw new NotImplementedException();
        }

        public List<APIResponseCallDTO> GetAPIResponseCallList()
        {
            throw new NotImplementedException();
        }
    }
}

//public async void AddStockToAccount(SearchDTO searchDTO)
//{
//    string Symbol = searchDTO.Symbol;

//    string Interval = searchDTO.Interval;

//    const string APIKEY = "ZN0C9Q4C0LG3REEE";

//    const string BaseUrl = "https://www.alphavantage.co/query";

//    string ApiFunction = "TIME_SERIES_INTRADAY";

//    string apiurl = $"{BaseUrl}?function={ApiFunction}&symbol={Symbol}&interval={Interval}&apikey={APIKEY}";

//    using (HttpClient client = new HttpClient())
//    {
//        HttpResponseMessage response = await client.GetAsync(apiurl);
//        if (response.IsSuccessStatusCode)
//        {
//            string json = await response.Content.ReadAsStringAsync();
//            var data = JObject.Parse(json);

//            string symbolName = data?["Meta Data"]?["2. Symbol"]?.ToString();
//            //string lastRefreshed = data?["Meta Data"]?["3. Last Refreshed"]?.ToString();
//            //string interval = data?["Meta Data"]?["4. Interval"]?.ToString();
//            //string info = data?["Meta Data"]?["1. Information"]?.ToString();

//            var timeSeries = data?["Time Series " + "(" + Interval + ")"];
//            if (timeSeries != null)
//            {

//                foreach (JProperty property in timeSeries.Children<JProperty>())
//                {
//                    DateTime date = DateTime.Parse(property.Name);
//                    double open = double.Parse(property.Value["1. open"].ToString(), CultureInfo.GetCultureInfo("en-US"));
//                    double high = double.Parse(property.Value["2. high"].ToString(), CultureInfo.GetCultureInfo("en-US"));
//                    double low = double.Parse(property.Value["3. low"].ToString(), CultureInfo.GetCultureInfo("en-US"));
//                    double close = double.Parse(property.Value["4. close"].ToString(), CultureInfo.GetCultureInfo("en-US"));
//                    int volume = int.Parse(property.Value["5. volume"].ToString());

//                }
//            }
//        }
//    }
//}


//string selectQuery = "SELECT TOP 1 StockId, Date, Symbol, [Open], High, Low, [Close] FROM Stock ORDER BY Date DESC";
//using (SqlCommand selectCmd = new SqlCommand(selectQuery, Sqlcon))
//{
//    Sqlcon.Open();
//    SqlDataReader reader = selectCmd.ExecuteReader();
//    if (reader.Read())
//    {
//        long stockId = reader.GetInt64(0);
//        DateTime date = reader.GetDateTime(1);
//        string symbol = reader.GetString(2);
//        decimal open = reader.GetDecimal(3);
//        decimal high = reader.GetDecimal(4);
//        decimal low = reader.GetDecimal(5);
//        decimal close = reader.GetDecimal(6);

//        string insertquery = "INSERT INTO Stock (StockId, Date, Symbol, [Open], High, Low, [Close]) VALUES (@StockId, @Date, @Symbol, @Open, @High, @Low, @Close)";
//        using (SqlCommand insertCmd = new SqlCommand(insertquery, Sqlcon))
//        {
//            insertCmd.Parameters.AddWithValue("@StockId", stockId);
//            insertCmd.Parameters.AddWithValue("@Date", date);
//            insertCmd.Parameters.AddWithValue("@Symbol", symbol);
//            insertCmd.Parameters.AddWithValue("@Open", open);
//            insertCmd.Parameters.AddWithValue("@High", high);
//            insertCmd.Parameters.AddWithValue("@Low", low);
//            insertCmd.Parameters.AddWithValue("@Close", close);

//            //StockDTO stockDTO = new StockDTO(
//            //    stockDTO.StockID,
//            //    stockDTO.Date,
//            //    stockDTO.Symbol,
//            //    stockDTO.Open,
//            //    stockDTO.High,
//            //    stockDTO.Low,
//            //    stockDTO.Close,
//            //    stockDTO.Volume);

//            insertCmd.ExecuteNonQuery();
//        }
//    }
//    reader.Close();
//    Sqlcon.Close();
//}