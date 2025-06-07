using System.Net;
using System.Net.Mail;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using OutlookSmtpApp.Models;

public class EmailController : Controller
{
    private string xmlPath = "wwwroot/smtp_settings.xml";

    [HttpGet]
    public IActionResult Send()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Send(EmailModel model)
    {
        try
        {
            // XML'den SMTP bilgilerini oku
            SmtpSettings smtpSettings;
            XmlSerializer serializer = new XmlSerializer(typeof(SmtpSettings));
            using (var reader = new StreamReader(xmlPath))
            {
                smtpSettings = (SmtpSettings)serializer.Deserialize(reader);
            }

            // Özel SMTP sunucusu varsa onu kullan, yoksa seçileni kullan
            string smtpServer = string.IsNullOrWhiteSpace(smtpSettings.CustomSmtp)
                                ? smtpSettings.SmtpServer
                                : smtpSettings.CustomSmtp;

            var smtpClient = new SmtpClient(smtpServer)
            {
                Port = 587,
                Credentials = new NetworkCredential(smtpSettings.Email, smtpSettings.Password),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(smtpSettings.Email),
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
