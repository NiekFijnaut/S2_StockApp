using Business;
using Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult UserLogin() { }
    }
}
