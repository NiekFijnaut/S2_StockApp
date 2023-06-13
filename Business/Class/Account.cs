using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Account
    {
        public int AccountID { get; }
        public string Username { get; }
        public string PasswordHash { get; }
        public string Email { get; }
        public string Region { get; }
        public string Interest { get; }
        public DateTime Age { get; }

        public Account(int accountID, string username, string passwordHash, string email, string region, string interest, DateTime age)
        {
            AccountID = accountID;
            Username= username;
            PasswordHash= passwordHash;
            Email= email;
            Region= region;
            Interest= interest;
            Age= age;
        }
    }
}
