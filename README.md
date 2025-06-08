# 📧 Outlook SMTP Setup for ASP.NET

Bu proje, ASP.NET tabanlı bir web uygulamasında **Outlook SMTP** ayarlarını yapılandırmak ve e-posta gönderimi gerçekleştirmek için geliştirilmiştir. SMTP ayarları XML dosyası üzerinden yapılandırılır ve kullanıcı dostu bir arayüz ile yönetilir.

## 🔧 Özellikler

- Outlook SMTP ayarlarını XML dosyasında saklama
- Ayarları düzenlemek için bir yapılandırma arayüzü (`SettingsController`)
- SMTP üzerinden e-posta gönderimi (`EmailController`)
- SSL destekli ve kimlik doğrulamalı gönderim

---

## 📁 Proje Yapısı

OutlookSmtpApp/
│
├── Controllers/
│ ├── EmailController.cs # E-posta gönderme işlemleri
│ └── SettingsController.cs # SMTP ayarlarını yapılandırma
│
├── Models/
│ └── SmtpSettings.cs # SMTP yapılandırma modeli
│
├── Views/
│ ├── Email/Send.cshtml # E-posta gönderme arayüzü
│ └── Settings/Configure.cshtml # Ayar yapılandırma arayüzü
│
├── wwwroot/
│ └── smtp_settings.xml # SMTP ayarlarının tutulduğu XML dosyası
│
└── README.md # Proje açıklama dosyası

---

## 🔑 SMTP Ayarları

SMTP yapılandırma dosyası olan `smtp_settings.xml` aşağıdaki formatta olmalıdır:

```xml
<SmtpSettings>
  <Email>your-email@outlook.com</Email>
  <Password>your-password</Password>
  <SmtpServer>smtp.office365.com</SmtpServer>
  <CustomSmtp></CustomSmtp>
</SmtpSettings>
🚀 Kullanım
Projeyi çalıştırın.

/Settings/Configure adresine giderek Outlook SMTP bilgilerinizi girin ve kaydedin.

/Email/Send sayfasından test e-postası gönderin.

✅ Gereksinimler
.NET 6+ / ASP.NET Core MVC

SMTP bilgileri (Outlook hesabı , gmail vb)

E-posta gönderimi için doğru port (587) ve SSL etkinleştirilmiş olmalıdır

# Mail Gönderim Uygulaması

Bu uygulama ile kendi e-posta hesabınız üzerinden kolayca mail gönderebilirsiniz.

## ✉️ Kullanım

1. **Email Ayarları** sayfasına gidin.
2. Kendi **e-posta adresinizi** ve **uygulama şifrenizi (application password)** girerek giriş yapın.
3. Giriş işlemi başarılı olduktan sonra aşağıdaki bilgileri doldurun:
   - Alıcının e-posta adresi
   - Mail başlığı
   - Mail içeriği
4. Tüm bilgileri girdikten sonra "Gönder" butonuna tıklayarak mailinizi yollayabilirsiniz.

## ⚠️ Notlar

- Gmail gibi servislerde uygulama şifresi oluşturmak için [Google Hesap Ayarları](https://myaccount.google.com/security) sayfasından "Uygulama şifreleri" bölümünü kullanabilirsiniz.
- Girdiğiniz bilgiler sadece oturum süresince saklanır, güvenliğiniz için işlem bitiminde oturumu kapatmayı unutmayın.


