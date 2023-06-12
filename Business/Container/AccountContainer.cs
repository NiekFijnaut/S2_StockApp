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
        private IAccount _account;

        public AccountContainer(IAccount account)
        {
            _account = account;
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
                account.Age);
                _account.AddAccount(accountDTO);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Username has already been chosen")
                {
                    throw;
                }
            }
        }

        public Account GetAccount(string passwordhash, string username)
        {
            try
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
            catch(Exception ex)
            {
                if (ex.Message == "Account was not properly created")
                {
                    throw;
                }
                return null;
            }
        }
    }
}
