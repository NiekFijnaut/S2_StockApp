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
        SqlConnection Sqlcon = new SqlConnection("Server = mssqlstud.fhict.local; Database=dbi519852;User Id = dbi519852; Password=YourChosenCarry010;");
        
        public void AddAccount(AccountDTO accountDTO)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[Account] ([Username],[Email],[Region],[Interest],[Age],[StockID]) VALUES (@Username, @Email, @Region, @Interest, @Age, @StockID)");

            cmd.Parameters.AddWithValue("@Username", accountDTO.Username);
            cmd.Parameters.AddWithValue("@Email", accountDTO.Email);
            cmd.Parameters.AddWithValue("@Region", accountDTO.Region);
            cmd.Parameters.AddWithValue("@Interest", accountDTO.Interest);
            cmd.Parameters.AddWithValue("@Age", accountDTO.Age);
            cmd.Parameters.AddWithValue("@StockID", accountDTO.StockID);

            Sqlcon.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
