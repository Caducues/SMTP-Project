using System.Xml.Serialization;
using System.IO;
using Microsoft.AspNetCore.Mvc;

public class SettingsController : Controller
{
    private string xmlPath = "wwwroot/smtp_settings.xml";

    [HttpGet]
    public IActionResult Configure()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Configure(SmtpSettings model)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SmtpSettings));
        using (var writer = new StreamWriter(xmlPath))
        {
            serializer.Serialize(writer, model);
        }

        ViewBag.Message = "SMTP ayarları kaydedildi.";
        return View();
    }
}
