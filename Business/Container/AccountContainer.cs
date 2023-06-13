using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Data;
using Interface;

namespace Business
{
    public class AccountContainer
    {
        private IAccount _account;

        public AccountContainer(IAccount account)
        {
            _account = account;
        }

        public void CreateAccount(Account account)
        {
            
            string password = account.PasswordHash;

            SHA256 sha256 = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            if (password.Length < 8)
            {
                throw new Exception("Password must be more than 8 figures");
            }

            else if (!account.Email.Contains("@"))
            {
                throw new Exception("Email must contain '@'");
            }

            else
            {
                DateTime selectedDate = account.Age;
                DateTime currentDate = DateTime.Now;
                int age = DateTime.Today.Year - selectedDate.Year;
                if (selectedDate.Month > currentDate.Month || (selectedDate.Month == currentDate.Month && selectedDate.Day > currentDate.Day))
                {
                    age--;
                }

                if (age < 18)
                {
                    throw new Exception("Age must be 18 or older");
                }
                    
                AccountDTO accountDTO = new AccountDTO(
                account.AccountID,
                account.Username,
                account.PasswordHash,
                account.Email,
                account.Region,
                account.Interest,
                account.Age);
                _account.AddAccount(accountDTO);
            }
        }

        public Account GetAccount(string passwordhash, string username)
        {
            AccountDTO accountDTO = _account.Login(passwordhash, username);

            if (accountDTO != null)
            {
                Account account = new Account(
                    accountDTO.AccountID,
                    accountDTO.Username,
                    accountDTO.PasswordHash,
                    accountDTO.Email,
                    accountDTO.Region,
                    accountDTO.Interest,
                    accountDTO.Age);
                return account;
            }
            return null; 
        }
    }
}
