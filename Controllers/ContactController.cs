using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace wweblog.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;
        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string email, string subject, string message)
        {
            // Lấy cấu hình SMTP
            var smtpSection = _config.GetSection("Smtp");
            var smtpHost = smtpSection["Host"] ?? "";
            var smtpPort = int.TryParse(smtpSection["Port"], out var port) ? port : 587;
            var smtpUser = smtpSection["User"] ?? "";
            var smtpPass = smtpSection["Pass"] ?? "";
            var enableSsl = bool.TryParse(smtpSection["EnableSsl"], out var ssl) ? ssl : true;

            var mail = new MailMessage();
            mail.From = new MailAddress(smtpUser);
            mail.To.Add(smtpUser); // Gửi về email của bạn
            mail.Subject = $"[MyBlog] Liên hệ từ {name} - {subject}";
            mail.Body = $"Tên: {name}\nEmail: {email}\nTiêu đề: {subject}\nNội dung: {message}";

            using (var smtp = new SmtpClient(smtpHost, smtpPort))
            {
                smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtp.EnableSsl = enableSsl;
                try
                {
                    smtp.Send(mail);
                    ViewBag.Message = "Gửi liên hệ thành công!";
                }
                catch
                {
                    ViewBag.Message = "Gửi liên hệ thất bại. Vui lòng thử lại sau.";
                }
            }
            return View();
        }
    }
}
