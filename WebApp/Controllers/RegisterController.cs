using Azure.Messaging;
using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        AccountContainer accountContainer = new AccountContainer(new AccountDAL());

        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public AccountViewModel ToModel(Account account)
        {
            AccountViewModel accountViewModel = new AccountViewModel(
                account.AccountID,
                account.Username,
                account.PasswordHash,
                account.Email,
                account.Region,
                account.Interest,
                account.Age);
            return accountViewModel;
        }

        public IActionResult AddAccount(AccountViewModel accountViewModel)
        {
            string password = accountViewModel.PasswordHash;

            SHA256 sha256 = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            if (password.Length < 8)
            {
                //TODO error
            }
            
            else if (!accountViewModel.Email.Contains("@"))
            {
                //error
            }

            else
            {
                DateTime selectedDate = accountViewModel.Age;
                DateTime currentDate = DateTime.Now;
                int age = DateTime.Today.Year - selectedDate.Year;
                if (selectedDate.Month > currentDate.Month || (selectedDate.Month == currentDate.Month && selectedDate.Day > currentDate.Day))
                {
                    age--;
                }

                if (age < 18)
                {
                    //error
                }

                else
                {
                    Account account = new Account(
                        accountViewModel.AccountID,
                        accountViewModel.Username, 
                        hashedPassword, 
                        accountViewModel.Email, 
                        accountViewModel.Region, 
                        accountViewModel.Interest, 
                        accountViewModel.Age
                        );

                    try
                    {
                        
                        accountContainer.CreateAccount(account);
                        //show succes message
                       
                    }

                    catch (Exception exmsg)
                    {
                        //error
                    }
                }
            }
            return View("CreateAccount");
        }
    }
}


