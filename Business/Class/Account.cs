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
        public long? AccountID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string Interest { get; set; }
        public DateTime? Age { get; set; }
        public long? StockID { get; set; }

        public Account(string username, string passwordHash, string email, string region, string interest, DateTime? age)
        {
            Username= username;
            PasswordHash= passwordHash;
            Email= email;
            Region= region;
            Interest= interest;
            Age= age;
        }
    }
}
