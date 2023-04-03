using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Azure;
using Microsoft.Identity.Client;


namespace Data
{
    public class AccountDAL
    {
        SqlConnection Sqlcon = DataString.connection;
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 
        public void AddAccount(AccountDTO accountDTO)
        {
            string UsernameQuery = "SELECT COUNT(AccountID) FROM Account WHERE Username = @Username";

            using (SqlCommand cmd1 = new SqlCommand(UsernameQuery, Sqlcon))
            {
                // Add a parameter for the username
                cmd1.Parameters.AddWithValue("@username", accountDTO.Username);

                Sqlcon.Open();

                int count = (int)cmd1.ExecuteScalar();

                Sqlcon.Close();

                // If count is 0, the username is unique
                bool isUnique = count == 0;
                if (!isUnique)
                {
                    throw new Exception("Username has already been chosen");
                }

            }
            //using (SqlCommand cmd = new SqlCommand("INSERT INTO Account (Username, Email, Region, Interest, Age, StockID) VALUES (@Username, @Email, @Region, @Interest, @Age, @StockID)", Sqlcon))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Account (Username, Email, Region, Interest, Age) VALUES (@Username, @Email, @Region, @Interest, @Age)", Sqlcon))
            {

                cmd.Parameters.AddWithValue("@Username", accountDTO.Username);
                cmd.Parameters.AddWithValue("@Email", accountDTO.Email);
                cmd.Parameters.AddWithValue("@Region", accountDTO.Region);
                cmd.Parameters.AddWithValue("@Interest", accountDTO.Interest);
                cmd.Parameters.AddWithValue("@Age", accountDTO.Age);
                //cmd.Parameters.AddWithValue("@StockID", DBNull.Value);

                Sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
