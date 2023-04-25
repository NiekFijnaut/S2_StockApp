using CsvHelper.Configuration.Attributes;
using Interface;
using Interface.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Data
{
    public class StockDAL
    {
        SqlConnection Sqlcon = DataString.connection;
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 
        public void AddStock(StockDTO stockDTO, AccountStockDTO accountStockDTO)
        {
            string insertquery = "INSERT INTO Stock (Date, Symbol, [Open], High, Low, [Close], Volume) VALUES (@Date, @Symbol, @Open, @High, @Low, @Close, @Volume)";
            using (SqlCommand cmd = new SqlCommand(insertquery, Sqlcon))
            {
                cmd.Parameters.AddWithValue("@Date", stockDTO.Date);
                cmd.Parameters.AddWithValue("@Symbol", stockDTO.Symbol);
                cmd.Parameters.AddWithValue("@Open", stockDTO.Open);
                cmd.Parameters.AddWithValue("@High", stockDTO.High);
                cmd.Parameters.AddWithValue("@Low", stockDTO.Low);
                cmd.Parameters.AddWithValue("@Close", stockDTO.Close);
                cmd.Parameters.AddWithValue("@Volume", stockDTO.Volume);

                Sqlcon.Open();
                cmd.ExecuteNonQuery();
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
        public DataTable ShowAccountStock(AccountStockDTO accountStockDTO)
        {
            string Showquery = "SELECT * FROM AccountStock";
            SqlCommand cmd1 = new SqlCommand(Showquery, Sqlcon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            
            DataTable accountstockdataTable = new DataTable();
            adapter.Fill(accountstockdataTable);
            
            return accountstockdataTable;

        }

        public void UpdateStockTable(StockDTO stockDTO)
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
    }
}