using Microsoft.AspNetCore.Mvc;
using OutlookSmtpApp.Models;

namespace OutlookSmtpApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            // Sabit kullanıcı doğrulama
            if (model.Username == "admin" && model.Password == "1234")
            {
                TempData["IsLoggedIn"] = "true";
                return RedirectToAction("Send", "Email");
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
            return View();
        }
    }
}
