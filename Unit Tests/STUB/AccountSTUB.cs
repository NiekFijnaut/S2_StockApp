using Business;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.STUB
{
    public class AccountSTUB : IAccount
    {

        public AccountDTO CreateFakeAccountDTO;

        public void AddAccount(AccountDTO accountDTO)
        {
            CreateFakeAccountDTO= accountDTO;
        }

        public AccountDTO Login(string passwordhash, string username)
        {
            if (username == "jaap" && passwordhash == "87654321")
            {
                return new AccountDTO(1, 
                    username, 
                    passwordhash, 
                    "rik@fontys.nl",
                    "Europe (Northern Europe, Southern Europe, Eastern Europe, Western Europe)",
                    "Real Estate", 
                    new DateTime(1998, 10, 12));
            }

            return null;
        }        
    }
}
