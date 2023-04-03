using Interface;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class StockDAL
    {
        SqlConnection Sqlcon = DataString.connection;
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 
        public void AddStock(StockDTO stockDTO)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Stock (StockID, Name, Ticker, Price, Volume) VALUES (@StockID, @Name, @Ticker, @Price, @Volume)", Sqlcon))
            {

                cmd.Parameters.AddWithValue("@Name", stockDTO.Name);
                cmd.Parameters.AddWithValue("@Ticker", stockDTO.Ticker);
                cmd.Parameters.AddWithValue("@Price", stockDTO.Price);
                cmd.Parameters.AddWithValue("@Volume", stockDTO.Volume);

                Sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}