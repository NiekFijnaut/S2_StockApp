﻿using CsvHelper.Configuration.Attributes;
using Interface;
using Interface.DTO;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
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
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 
        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, int AccountID)
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
                getDateTimeCmd.Parameters.AddWithValue("@StockID", stockID); // Use stockID as parameter value for ID
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
                @"IF NOT EXISTS (SELECT 1 FROM AccountStock WHERE Symbol = @Symbol AND AccountID = @AccountID) 
                BEGIN INSERT INTO AccountStock (StockID, Date, Symbol, AccountID) VALUES (@StockID, @Date, @Symbol, @AccountID) END";
            using (SqlCommand cmd5 = new SqlCommand(insertQuery, Sqlcon))
            {
                cmd5.Parameters.AddWithValue("@StockID", stockID);
                cmd5.Parameters.AddWithValue("@Date", date);
                cmd5.Parameters.AddWithValue("@Symbol", symbol);
                cmd5.Parameters.AddWithValue("@AccountID", AccountID);

                Sqlcon.Open();
                cmd5.ExecuteNonQuery();
                Sqlcon.Close();
            }

        }

        public List<AccountStockDTO> GetAccountStockList(int AccountID)
        {
            Sqlcon.Open();
            List<AccountStockDTO> accountStockList = new();
            using (SqlCommand cmd1 = new("SELECT Date, Symbol FROM AccountStock WHERE AccountID = @AccountID", Sqlcon))
            {
                cmd1.Parameters.AddWithValue("@AccountID", AccountID);

                using SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    accountStockList.Add(
                    new AccountStockDTO(
                        null,
                        reader1.GetDateTime("Date"),
                        reader1.GetString("Symbol"),
                        AccountID));
                }
                Sqlcon.Close();
                return accountStockList;
            }
        }

        public List<FavoriteDTO> GetFavoriteList(int AccountID)
        {
            Sqlcon.Open();
            List<FavoriteDTO> favoriteList = new();
            using (SqlCommand cmd1 = new("SELECT Symbol FROM Favorite WHERE AccountID = @AccountID", Sqlcon))
            {
                cmd1.Parameters.AddWithValue("@AccountID", AccountID);

                using SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    favoriteList.Add(
                    new FavoriteDTO(
                        null,
                        reader1.GetString("Symbol"),
                        AccountID));
                }
                Sqlcon.Close();
                return favoriteList;
            }
        }

        long StockID;
        public void AddToFavorite(int AccountID, string Symbol)
        {
            string SelectStockID = "SELECT StockID From AccountStock WHERE AccountID = @AccountID AND Symbol = @Symbol";
            using (SqlCommand cmd2 = new(SelectStockID, Sqlcon))
            {
                cmd2.Parameters.AddWithValue("@AccountID", AccountID);
                cmd2.Parameters.AddWithValue("@Symbol", Symbol);
                Sqlcon.Open();
                using SqlDataReader reader = cmd2.ExecuteReader(); //TODO is null
                while (reader.Read())
                {
                    StockID = reader.GetInt64(0);
                }
                Sqlcon.Close();
            }

            string Favoritequery = "IF NOT EXISTS (SELECT 1 FROM Favorite WHERE Symbol = @Symbol AND AccountID = @AccountID) " +
                "BEGIN INSERT INTO Favorite (StockID, Symbol, AccountID) VALUES (@StockID, @Symbol, @AccountID) END";
            using (SqlCommand cmd3 = new(Favoritequery, Sqlcon))
            {
                cmd3.Parameters.AddWithValue("@StockID", StockID);
                cmd3.Parameters.AddWithValue("@Symbol", Symbol);
                cmd3.Parameters.AddWithValue("@AccountID", AccountID);

                Sqlcon.Open();
                cmd3.ExecuteNonQuery();
                Sqlcon.Close();
            }
        }

        public void DeleteStock(string symbol, int AccountID)
        {
            string deletequery = "DELETE FROM AccountStock WHERE Symbol = @Symbol AND Account = @AccountID";
            using (SqlCommand cmd4 = new SqlCommand(deletequery, Sqlcon))
            {
                cmd4.Parameters.AddWithValue("@Symbol", symbol);
                cmd4.Parameters.AddWithValue("@AccountID", AccountID);

                Sqlcon.Open();
                cmd4.ExecuteNonQuery();
                Sqlcon.Close();
            }
            
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

