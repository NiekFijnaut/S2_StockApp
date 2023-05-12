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
        public void AddStock(StockDTO stockDTO, APIResponseCallDTO aPIResponseCallDTO, AccountStockDTO accountStockDTO)
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

            string selectQuery = "SELECT TOP 1 StockId, Date, Symbol, [Open], High, Low, [Close] FROM Stock ORDER BY Date DESC";
            using (SqlCommand selectCmd = new SqlCommand(selectQuery, Sqlcon))
            {
                Sqlcon.Open();
                SqlDataReader reader = selectCmd.ExecuteReader();
                if (reader.Read())
                {
                    long stockId = reader.GetInt64(0);
                    DateTime date = reader.GetDateTime(1);
                    string symbol = reader.GetString(2);
                    decimal open = reader.GetDecimal(3);
                    decimal high = reader.GetDecimal(4);
                    decimal low = reader.GetDecimal(5);
                    decimal close = reader.GetDecimal(6);

                    string insertquery = "INSERT INTO Stock (StockId, Date, Symbol, [Open], High, Low, [Close]) VALUES (@StockId, @Date, @Symbol, @Open, @High, @Low, @Close)";
                    using (SqlCommand insertCmd = new SqlCommand(insertquery, Sqlcon))
                    {
                        insertCmd.Parameters.AddWithValue("@StockId", stockId);
                        insertCmd.Parameters.AddWithValue("@Date", date);
                        insertCmd.Parameters.AddWithValue("@Symbol", symbol);
                        insertCmd.Parameters.AddWithValue("@Open", open);
                        insertCmd.Parameters.AddWithValue("@High", high);
                        insertCmd.Parameters.AddWithValue("@Low", low);
                        insertCmd.Parameters.AddWithValue("@Close", close);

                        insertCmd.ExecuteNonQuery();
                    }
                }
                reader.Close();
                Sqlcon.Close();
            }

            string insertQuery = "INSERT INTO AccountStock (Date, Symbol) " +
               "SELECT TOP 1 @Date, @Symbol " +
               "FROM AccountStock " +
               "ORDER BY Date DESC";
            using (SqlCommand cmd5 = new SqlCommand(insertQuery, Sqlcon))
            {
                cmd5.Parameters.AddWithValue("@Date", accountStockDTO.Date);
                cmd5.Parameters.AddWithValue("@Symbol", accountStockDTO.Symbol);

                Sqlcon.Open();
                cmd5.ExecuteNonQuery();
                Sqlcon.Close();
            }
        }
        
        public List<AccountStockDTO> GetAccountStockList()
        {
            Sqlcon.Open();
            List<AccountStockDTO> accountStockDTOList = new();
            using SqlCommand cmd1 = new("SELECT Date, Symbol FROM [dbo].[AccountStock]", Sqlcon);
            using SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                accountStockDTOList.Add(
                new AccountStockDTO(
                    null,
                    reader.GetDateTime("Date"),
                    reader.GetString("Symbol"),
                    null));
            }
            Sqlcon.Close();
            return accountStockDTOList;
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
                string insrtQuery = "INSERT INTO stock (Date, Symbol) VALUES (@Date, @Symbol)";
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