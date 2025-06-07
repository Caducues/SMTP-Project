public class SmtpSettings
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string SmtpServer { get; set; }
    public string CustomSmtp { get; set; } // Boş değilse bunu kullanacağız
}
