using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateAccount(Account account)
        {
            AccountDTO accountDTO = new AccountDTO(account.Username, account.Email, account.Region, account.Interest, account.Age, account.StockID);
            accountDAL.AddAccount(accountDTO);
        }
    }
}
