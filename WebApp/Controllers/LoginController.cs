using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        AccountContainer accountContainer = new AccountContainer(new AccountDAL());

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(AccountViewModel accountViewModel)
        {
            HttpContext.Session.SetString("Username", accountViewModel.Username);
            HttpContext.Session.SetString("Interest", accountViewModel.Interest);
            HttpContext.Session.SetInt32("AccountID", accountViewModel.AccountID);

            Account account = new Account(
                accountViewModel.AccountID,
                accountViewModel.Username,
                accountViewModel.PasswordHash,
                null,
                null,
                null,
                accountViewModel.Age
                );  

            if (accountContainer.passwordMatches(account))
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
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
