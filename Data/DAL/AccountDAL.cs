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
using Serilog;

namespace Data
{
    public class AccountDAL : Interface.IAccount
    {
        SqlConnection Sqlcon = DataString.connection;
        //sql connection string naar een aparte functie zodat deze mee kan veranderen als het wachtwoord veranderd bijvoorbeeld en overal aangeroepen kan worden 

        public void AddAccount(AccountDTO accountDTO)
        {
            try
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

                    Sqlcon.Open();
                    cmd.ExecuteNonQuery();
                    Sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Username has already been chosen")
                {
                    throw;
                }
                string errorMessage = $"[{DateTime.Now}] {"create account failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
            }
        }

        public AccountDTO Login(string passwordhash, string username)
        {
            try
            {
                string PasswordHashQuery = "SELECT * FROM Account WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(PasswordHashQuery, Sqlcon))
                {
                    Sqlcon.Open();
                    command.Parameters.AddWithValue("@Username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int accountId = reader.GetInt32(0);
                        string username1 = reader.GetString(1);
                        string hashedPassword = reader.GetString(2);
                        string email = reader.GetString(3);
                        string region = reader.GetString(4);
                        string interest = reader.GetString(5);
                        DateTime age = reader.GetDateTime(6);

                        // ingevoerde wachtwoord hashen en vergelijken
                        SHA256 sha256 = SHA256.Create();
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordhash);
                        byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                        string enteredHash = Convert.ToBase64String(hashedBytes);
                        bool passwordMatches = (hashedPassword == enteredHash);
                        if(!passwordMatches)
                        {
                            throw new Exception("Password doesn't match username");
                        }

                        Sqlcon.Close();

                        if (passwordMatches)
                        {
                            AccountDTO accountDTO = new AccountDTO(accountId, username1, hashedPassword, email, region, interest, age);

                            return accountDTO;
                        }
                    }
                }
                return null;
            }
            catch(Exception ex) 
            { 
                string errorMessage = $"[{DateTime.Now}] {"Login failed"}{Environment.NewLine}";
                File.AppendAllText(@"C:\apps\StockApp\Error.txt", errorMessage);
                Sqlcon.Close();
                return null;
            }
        }
    }
}
