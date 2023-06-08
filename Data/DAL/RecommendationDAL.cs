using Interface;
using Interface.DTO;
using Interface.Interface;
using Microsoft.Data.SqlClient;
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

        List<IRecommendation> IRecommendation.GetRecommendations(string interest)
        {
            throw new NotImplementedException();
        }
    }
}
