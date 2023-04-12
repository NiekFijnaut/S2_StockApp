using Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HistorieDAL
    {
        SqlConnection Sqlcon = DataString.connection;
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
    }
}
