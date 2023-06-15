using CsvHelper.Configuration.Attributes;
using Interface;
using Interface.DTO;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Data;
using System.Globalization;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Data
{
    public class StockDAL : IStock, IAlphaVantage
    {
        SqlConnection Sqlcon = DataString.connection;
        
        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID)
        {
            try
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
               
                long stockID;
                using (SqlCommand getStockIDCmd = new SqlCommand("SELECT IDENT_CURRENT('APIResponseCall')", Sqlcon))
                {
                    Sqlcon.Open();
                    stockID = Convert.ToInt64(getStockIDCmd.ExecuteScalar());
                    Sqlcon.Close();
                }

                DateTime date = DateTime.MinValue;
                string symbol = string.Empty;
                using (SqlCommand getDateTimeCmd = new SqlCommand("SELECT [Date], Symbol FROM APIResponseCall WHERE StockID = @StockID", Sqlcon))
                {
                    getDateTimeCmd.Parameters.AddWithValue("@StockID", stockID); 
                    Sqlcon.Open();
                    using (SqlDataReader reader = getDateTimeCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            date = reader.GetDateTime(0);
                            symbol = reader.GetString(1);
                        }
                    }
                    Sqlcon.Close();
                }
                
                string insertQuery =
                @"IF NOT EXISTS (SELECT 1 FROM AccountStock WHERE StockID = @StockID AND AccountID = @AccountID) 
                BEGIN INSERT INTO AccountStock (StockID, AccountID) VALUES (@StockID, @AccountID) END";
                using (SqlCommand cmd5 = new SqlCommand(insertQuery, Sqlcon))
                {
                    cmd5.Parameters.AddWithValue("@StockID", stockID);
                    cmd5.Parameters.AddWithValue("@AccountID", AccountID);

                    Sqlcon.Open();
                    cmd5.ExecuteNonQuery();
                    Sqlcon.Close();
                }
            }
            catch(Exception ex)
            {
                string errorMessage = $"[{DateTime.Now}] {"Add stock failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
            }
        }

        public List<AccountStockDTO> GetAccountStockList(int AccountID)
        {
            try
            {
                Sqlcon.Open();
                List<AccountStockDTO> accountStockList = new();
                using (SqlCommand cmd1 = new("SELECT api.StockID, api.Symbol, api.Date FROM AccountStock AS accountstock JOIN APIResponseCall AS api ON accountstock.StockID = api.StockID WHERE accountstock.AccountID = @AccountID", Sqlcon))
                {
                    cmd1.Parameters.AddWithValue("@AccountID", AccountID);

                    using SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        accountStockList.Add(
                        new AccountStockDTO(
                            reader1.GetInt64("StockID"),
                            reader1.GetDateTime("Date"),
                            reader1.GetString("Symbol"),
                            AccountID));
                    }
                    Sqlcon.Close();
                    return accountStockList;
                }
            }
            catch(Exception ex)
            {
                string errorMessage = $"[{DateTime.Now}] {"Get account stocks failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
                return new List<AccountStockDTO>();
            }
        }

        public List<FavoriteDTO> GetFavoriteList(int AccountID)
        {
            try
            {
                Sqlcon.Open();
                List<FavoriteDTO> favoriteList = new();
                using (SqlCommand cmd1 = new("SELECT api.StockID, api.Symbol FROM Favorite AS favorite JOIN APIResponseCall AS api ON favorite.StockID = api.StockID WHERE favorite.AccountID = @AccountID", Sqlcon))
                {
                    cmd1.Parameters.AddWithValue("@AccountID", AccountID);

                    using SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        favoriteList.Add(
                        new FavoriteDTO(
                            reader1.GetInt64("StockID"),
                            reader1.GetString("Symbol"),
                            AccountID));
                    }
                    Sqlcon.Close();
                    return favoriteList;
                }
            }
            catch(Exception ex)
            {
                string errorMessage = $"[{DateTime.Now}] {"Get favorites failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
                return new List<FavoriteDTO>();
            }
        }

        public void AddToFavorite(FavoriteDTO favoriteDTO)
        {
            try
            {
                //string SelectStockID = "SELECT Symbol From AccountStock WHERE AccountID = @AccountID AND StockID = @StockID";// TODO
                //using (SqlCommand cmd2 = new(SelectStockID, Sqlcon))
                //{
                //    cmd2.Parameters.AddWithValue("@AccountID", favoriteDTO.AccountID);
                //    cmd2.Parameters.AddWithValue("@Symbol", favoriteDTO.StockID);
                //    Sqlcon.Open();
                //    using SqlDataReader reader = cmd2.ExecuteReader(); 
                //    while (reader.Read())
                //    {
                //        Symbol = reader.GetString(0);
                //    }
                //    Sqlcon.Close();
                //}

                string Favoritequery = "IF NOT EXISTS (SELECT 1 FROM Favorite WHERE StockID = @StockID AND AccountID = @AccountID) " +
                    "BEGIN INSERT INTO Favorite (StockID, AccountID) VALUES (@StockID, @AccountID) END";
                using (SqlCommand cmd3 = new(Favoritequery, Sqlcon))
                {
                    cmd3.Parameters.AddWithValue("@StockID", favoriteDTO.StockID);
                    cmd3.Parameters.AddWithValue("@AccountID", favoriteDTO.AccountID);

                    Sqlcon.Open();
                    cmd3.ExecuteNonQuery();
                    Sqlcon.Close();
                }
            }
            catch( Exception ex)
            {
                string errorMessage = $"[{DateTime.Now}] {"Add favorites failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
            }
        }

        public void DeleteStock(AccountStockDTO accountStockDTO)
        {
            try
            {
                string deletequery = "DELETE FROM AccountStock WHERE StockID = @StockID AND AccountID = @AccountID";
                using (SqlCommand cmd4 = new SqlCommand(deletequery, Sqlcon))
                {
                    cmd4.Parameters.AddWithValue("@StockID", accountStockDTO.StockID);
                    cmd4.Parameters.AddWithValue("@AccountID", accountStockDTO.AccountID);

                    Sqlcon.Open();
                    cmd4.ExecuteNonQuery();
                    Sqlcon.Close();
                }
            }
            catch(Exception ex)
            {
                string errorMessage = $"[{DateTime.Now}] {"Delete stock failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
            }
        }

        public void DeleteFavorite(FavoriteDTO favoriteDTO)
        {
            try
            {
                string deletequery = "DELETE FROM Favorite WHERE StockID = @StockID AND AccountID = @AccountID";
                using (SqlCommand cmd4 = new SqlCommand(deletequery, Sqlcon))
                {
                    cmd4.Parameters.AddWithValue("@StockID", favoriteDTO.StockID);
                    cmd4.Parameters.AddWithValue("@AccountID", favoriteDTO.AccountID);

                    Sqlcon.Open();
                    cmd4.ExecuteNonQuery();
                    Sqlcon.Close();
                }
            }
            catch(Exception ex)
            {
                string errorMessage = $"[{DateTime.Now}] {"Delete favorites failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
            }
        }

        public Task<List<APIResponseCallDTO>> SearchStock(SearchDTO searchDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<HistorieDTO>> SearchHistorieStock(SearchDTO searchDTO)
        {
            throw new NotImplementedException();
        }
    }
}

