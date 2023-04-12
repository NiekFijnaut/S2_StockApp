using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Azure;
using Microsoft.Identity.Client;
using System.Security.Cryptography;

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
                cmd1.Parameters.AddWithValue("@username", accountDTO.Username);

                Sqlcon.Open();

                int count = (int)cmd1.ExecuteScalar();

                Sqlcon.Close();

                // If count is 0, username is uniek
                bool isUnique = count == 0;
                if (!isUnique)
                {
                    throw new Exception("Username has already been chosen");
                }
            }

            //using (SqlCommand cmd = new SqlCommand("INSERT INTO Account (Username, Email, Region, Interest, Age, StockID) VALUES (@Username, @Email, @Region, @Interest, @Age, @StockID)", Sqlcon))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Account (Username, PasswordHash, Email, Region, Interest, Age) VALUES (@Username, @PasswordHash, @Email, @Region, @Interest, @Age)", Sqlcon))
            {

                cmd.Parameters.AddWithValue("@Username", accountDTO.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", accountDTO.PasswordHash);
                cmd.Parameters.AddWithValue("@Email", accountDTO.Email);
                cmd.Parameters.AddWithValue("@Region", accountDTO.Region);
                cmd.Parameters.AddWithValue("@Interest", accountDTO.Interest);
                cmd.Parameters.AddWithValue("@Age", accountDTO.Age);
                //cmd.Parameters.AddWithValue("@StockID", DBNull.Value);

                Sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool VerifyPassword(AccountDTO accountDTO)
        {
            string PasswordHashQuery = "SELECT PasswordHash, AccountID FROM Account WHERE Username = @Username";

            using SqlCommand command = new SqlCommand(PasswordHashQuery, Sqlcon);
            {
                command.Parameters.AddWithValue("@Username", accountDTO.Username);
                string hashedPassword = (string)command.ExecuteScalar();

                // ingevoerde wachtwoord hashen en vergelijken
                SHA256 sha256 = SHA256.Create();
                byte[] passwordBytes = Encoding.UTF8.GetBytes(accountDTO.PasswordHash);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                string enteredHash = Convert.ToBase64String(hashedBytes);
                bool passwordMatches = (hashedPassword == enteredHash);

                if (!passwordMatches)
                {
                    throw new Exception("Password doesn't match with the Username");
                }

                return passwordMatches; 
            }
        }
    }
}
