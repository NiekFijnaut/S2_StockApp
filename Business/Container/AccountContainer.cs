using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Data;
using Interface;

namespace Business
{
    public class AccountContainer
    {
        private AccountDAL accountDAL = new AccountDAL();

        public AccountContainer()
        {

        }

        public void CreateAccount(Account account)
        {
            try
            {
                AccountDTO accountDTO = new AccountDTO(
                account.AccountID,
                account.Username,
                account.PasswordHash,
                account.Email,
                account.Region,
                account.Interest,
                account.Age,
                account.StockID);
                accountDAL.AddAccount(accountDTO);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Username has already been chosen")
                {
                    throw;
                }
            }
        }

        public bool passwordMatches(Account account)
        {
            AccountDTO accountDTO = new AccountDTO(null, account.Username, account.PasswordHash, null, null, null, null, null);

            AccountDAL accountDAL = new AccountDAL(); 

            bool passwordMatches = accountDAL.VerifyPassword(accountDTO); 

            if (passwordMatches)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }
    }
}
