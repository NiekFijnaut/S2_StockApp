using Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Data
{
    public class StockDAL
    {
        SqlConnection Sqlcon = DataString.connection;
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 
        public void AddStock(StockDTO stockDTO)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Stock (Date, Symbol, [Open], High, Low, [Close], Volume) VALUES (@Date, @Symbol, @Open, @High, @Low, @Close, @Volume)", Sqlcon))
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
        }
        public StockDTO ViewStockBySymbol(string symbol)
        {
            string query = "SELECT TOP 1 Date, Symbol FROM stock WHERE Symbol = @Symbol ORDER BY Date DESC";
            SqlCommand cmd1 = new SqlCommand(query, Sqlcon);
            cmd1.Parameters.AddWithValue("@Symbol", symbol);
            SqlDataReader reader = cmd1.ExecuteReader();
            
            reader.Close();

            StockDTO stockDTO1 = new StockDTO(null, reader.GetDateTime("Date"), reader.GetString("Symbol"), null, null, null, null, null);
            return stockDTO1;
        }

        public void UpdateSTockTable(StockDTO stockDTO)
        {
            string updateQuery = "UPDATE stock SET Date = @Date WHERE Symbol = @Symbol";
            SqlCommand cmd2 = new SqlCommand(updateQuery, Sqlcon);
            cmd2.Parameters.AddWithValue("@Symbol", stockDTO.Symbol);
            cmd2.Parameters.AddWithValue("@Date", stockDTO.Date);
            int rowsAffected = cmd2.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                string insertQuery = "INSERT INTO stock (Date, Symbol) VALUES (@Date, @Symbol)";
                SqlCommand cmd3 = new SqlCommand(insertQuery, Sqlcon);
                cmd3.Parameters.AddWithValue("@Symbol", stockDTO.Symbol);
                cmd3.Parameters.AddWithValue("@Date", stockDTO.Date);
                cmd3.ExecuteNonQuery();
            }
        }
    }
}