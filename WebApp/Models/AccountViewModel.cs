using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AccountViewModel
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string Interest { get; set; }
        public DateTime Age { get; set; }

        public AccountViewModel()
        {

        }

        public AccountViewModel(int accountID, string username, string passwordHash, string email, string region, string interest, DateTime age) 
        {
            AccountID = accountID;
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            Region = region;
            Interest = interest;
            Age = age;
        }
    }
}
