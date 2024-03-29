﻿using Business;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private AccountContainer _accountContainer;

        public LoginController()
        {
            _accountContainer = new AccountContainer(new AccountDAL());
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                string passwordhash = loginViewModel.PasswordHash;
                string username = loginViewModel.Username;

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
            }
            return RedirectToAction("Login", "Login");
        }
    }
}
