﻿using Business;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private AccountContainer _accountContainer;

        public LoginController()
        {
            _accountContainer = new AccountContainer();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(AccountViewModel accountViewModel)
        {
            string passwordhash = accountViewModel.PasswordHash;
            string username = accountViewModel.Username;

            Account account = _accountContainer.GetAccount(passwordhash, username);

            if (account != null)
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("Username", account.Username);
                HttpContext.Session.SetString("Interest", account.Interest);
                HttpContext.Session.SetInt32("AccountID", account.AccountID);
                
                // Redirect to the desired page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Password does not match, display error message or redirect back to login page
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
