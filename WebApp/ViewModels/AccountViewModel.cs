using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class AccountViewModel
    {
        
        public int AccountID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Interest { get; set; }
        [Required]
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
