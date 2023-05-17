using CsvHelper.Configuration.Attributes;
using Interface;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace Data
{
    public class StockDAL : IStock
    {
        SqlConnection Sqlcon = DataString.connection;
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 
        public void AddStock(APIResponseCallDTO aPIResponseCallDTO, AccountStockDTO accountStockDTO)
        {
            string apiinsertquery = "INSERT INTO APIResponseCall (StockID, Date, Symbol, [Open], High, Low, [Close]) VALUES (@StockID, @Date, @Symbol, @Open, @High, @Low, @Close)";
            using (SqlCommand apiinsertCmd = new SqlCommand(apiinsertquery, Sqlcon))
            {
                Sqlcon.Open();
                apiinsertCmd.Parameters.AddWithValue("@StockID", aPIResponseCallDTO.StockID);
                apiinsertCmd.Parameters.AddWithValue("@Date", aPIResponseCallDTO.Date);
                apiinsertCmd.Parameters.AddWithValue("@Symbol", aPIResponseCallDTO.Symbol);
                apiinsertCmd.Parameters.AddWithValue("@Open", aPIResponseCallDTO.Open);
                apiinsertCmd.Parameters.AddWithValue("@High", aPIResponseCallDTO.High);
                apiinsertCmd.Parameters.AddWithValue("@Low", aPIResponseCallDTO.Low);
                apiinsertCmd.Parameters.AddWithValue("@Close", aPIResponseCallDTO.Close);

                apiinsertCmd.ExecuteNonQuery();
                Sqlcon.Close();
            }

            string insertQuery = 
                @"IF NOT EXISTS (SELECT 1 FROM AccountStock WHERE Symbol = @Symbol) 
                BEGIN INSERT INTO AccountStock (Date, Symbol) SELECT TOP 1 @Date, @Symbol FROM AccountStock ORDER BY Date DESC END";
            using (SqlCommand cmd5 = new SqlCommand(insertQuery, Sqlcon))
            {
                cmd5.Parameters.AddWithValue("@Date", accountStockDTO.Date);
                cmd5.Parameters.AddWithValue("@Symbol", accountStockDTO.Symbol);

                Sqlcon.Open();
                cmd5.ExecuteNonQuery();
                Sqlcon.Close();
            }
        }
        
        public List<APIResponseCallDTO> GetAPIResponseCallList()
        {
            Sqlcon.Open();
            List<APIResponseCallDTO> apiResponseList = new List<APIResponseCallDTO>();
            using SqlCommand cmd6 = new("SELECT Date, Symbol, [Open], High, Low, [Close] FROM [dbo].[AccoutnStock]", Sqlcon);
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
                        reader6.GetInt32("Volume"));
            }
            Sqlcon.Close ();
            return apiResponseList;
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

        public void UpdateStockTable(APIResponseCallDTO stockDTO)
        {
            string updateQuery = "UPDATE stock SET Date = @Date WHERE Symbol = @Symbol";
            SqlCommand cmd2 = new SqlCommand(updateQuery, Sqlcon);
            cmd2.Parameters.AddWithValue("@Symbol", stockDTO.Symbol);
            cmd2.Parameters.AddWithValue("@Date", stockDTO.Date);
            int rowsAffected = cmd2.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                string insrtQuery = "INSERT INTO AccountStock (Date, Symbol) VALUES (@Date, @Symbol)";
                SqlCommand cmd3 = new SqlCommand(insrtQuery, Sqlcon);
                cmd3.Parameters.AddWithValue("@Symbol", stockDTO.Symbol);
                cmd3.Parameters.AddWithValue("@Date", stockDTO.Date);
                cmd3.ExecuteNonQuery();
            }
        }

        public void DeleteStock(ulong stockId)
        {
            string deletequery = "DELETE FROM Stock WHERE StockID = @StockID";
            SqlCommand cmd4 = new SqlCommand(deletequery, Sqlcon);
            cmd4.ExecuteNonQuery();
        }

        void IStock.GetAccountStockList()
        {
            throw new NotImplementedException();
        }

        public void AddStock(StockDTO stockDTO, AccountStockDTO accountStockDTO, APIResponseCallDTO aPIResponseCallDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateStockTable(StockDTO stockDTO)
        {
            throw new NotImplementedException();
        }

        public void AddStock(APIResponseCallDTO stockDTO, AccountStockDTO accountStockDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteStock(APIResponseCallDTO stockDTO)
        {
            throw new NotImplementedException();
        }
    }
}


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