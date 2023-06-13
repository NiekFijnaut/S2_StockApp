using Interface;
using Interface.DTO;
using Interface.Interface;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class RecommendationDAL : IRecommendation
    {
        SqlConnection Sqlcon = DataString.connection;

        public List<RecommendationDTO> GetRecommendations(string interest) 
        {
            try
            {
                Sqlcon.Open();
                List<RecommendationDTO> recommendationList = new List<RecommendationDTO>();
                using (SqlCommand cmd1 = new("SELECT Name FROM Recommendation WHERE Interest = @Interest", Sqlcon))
                {
                    cmd1.Parameters.AddWithValue("@Interest", interest);

                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            recommendationList.Add(
                                new RecommendationDTO(
                                    null,
                                    interest,
                                    reader.GetString("Name")
                                    ));
                        }
                    }
                }
                Sqlcon.Close();
                return recommendationList;
            }
            catch(Exception ex)
            {
                string errorMessage = $"[{DateTime.Now}] {"Get recommendation intel failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                return new List<RecommendationDTO>();
            }
        }
    }
}
