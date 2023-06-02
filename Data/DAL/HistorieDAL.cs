using Interface;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HistorieDAL : IHistorie
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

        public List<HistorieDTO> ViewHistorie(HistorieDTO historieDTO)
        {
            List<HistorieDTO> Historielist = new List<HistorieDTO>();
            using (SqlCommand cmd1 = new SqlCommand("SELECT Date, Symbol, Open, High, Low, Close, Volume FROM Historie", Sqlcon))
            {
                Sqlcon.Open();
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //HistorieDTO historie = new HistorieDTO();
                        //historie.Date = (DateTime)reader["Date"];
                        //historie.Symbol = (string)reader["Symbol"];
                        //historie.Open = (decimal)reader["Open"];
                        //historie.High = (decimal)reader["High"];
                        //historie.Low = (decimal)reader["Low"];
                        //historie.Close = (decimal)reader["Close"];
                        //historie.Volume = (int)reader["Volume"];

                        //Historielist.Add(historie);
                    }
                }
            }
            return Historielist;
        }

    }
}
