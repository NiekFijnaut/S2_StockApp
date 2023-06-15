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
        private AccountContainer _accountContainer;

        public RegisterController()
        {
            _accountContainer = new AccountContainer(new AccountDAL());
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult AddAccount(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Account account = new Account(
                       accountViewModel.AccountID,
                       accountViewModel.Username,
                       accountViewModel.PasswordHash,
                       accountViewModel.Email,
                       accountViewModel.Region,
                       accountViewModel.Interest,
                       accountViewModel.Age
                       );
                    _accountContainer.CreateAccount(account);
                    ViewBag.Message = "Account has been created";
                }
            }
            catch (Exception ex)
            {
                TempData["CreateAccountError"] = ex.Message;
            }
            return View("CreateAccount");
        }
    }
}


