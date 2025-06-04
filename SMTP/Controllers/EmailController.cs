using Microsoft.AspNetCore.Mvc;
using OutlookSmtpApp.Models;
using System.Net;
using System.Net.Mail;

namespace OutlookSmtpApp.Controllers
{
    public class EmailController : Controller
    {
        [HttpGet]
        public IActionResult Send()
        {
            if (TempData["IsLoggedIn"]?.ToString() != "true")
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult Send(EmailModel model)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("tahaakyuz8@gmail.com", "uklg oczk wpnd hksf"),
                    EnableSsl = true
                };

                var mail = new MailMessage
                {
                    From = new MailAddress("tahaakyuz8@gmail.com"),
                    Subject = model.Subject,
                    Body = model.Body,
                    IsBodyHtml = true
                };
                mail.To.Add(model.To);

                smtpClient.Send(mail);

                ViewBag.Message = "E-posta başarıyla gönderildi.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "E-posta gönderilemedi: " + (ex?.Message ?? "Bilinmeyen hata.");
            }


            return View();
        }
    }
}
