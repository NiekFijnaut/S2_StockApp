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
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Stock (StockID, AdjustedClose, Date, Symbol, Open, High, Low, Close, DividendAmount, Volume) VALUES (@StockID, @AdjustedClose, @Date, @Symbol, @Open, @High, @Low, @Close, @DividendAmount, @Volume)", Sqlcon))
            {

                cmd.Parameters.AddWithValue("@AdjustedCLose", stockDTO.AdjustedClose);
                cmd.Parameters.AddWithValue("@Date", stockDTO.Date);
                cmd.Parameters.AddWithValue("@Symbol", stockDTO.Symbol);
                cmd.Parameters.AddWithValue("@Open", stockDTO.Open);
                cmd.Parameters.AddWithValue("@High", stockDTO.High);
                cmd.Parameters.AddWithValue("@Low", stockDTO.Low);
                cmd.Parameters.AddWithValue("@Close", stockDTO.Close);
                cmd.Parameters.AddWithValue("@DividendAmount", stockDTO.DividendAmount);
                cmd.Parameters.AddWithValue("@Volume", stockDTO.Volume);

                Sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}