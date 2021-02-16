﻿using Framework.Infrastructure;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Services.Email
{
    public class GmailSender : IEmailSender
    {
        private readonly string SenderTitle;
        private readonly string UserName;
        private readonly string Password;
        private readonly int Port;
        private readonly bool UseSSL;
        private readonly ILogger _logger;

        public GmailSender(ILogger logger)
        {
            _logger = logger;
            SenderTitle = "PrancaBeauty Shop";
            UserName = "arshambh9@gmail.com";
            Password = "1234567898";
            Port = 587;
            UseSSL = true;
        }

        public bool Send(string to, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(UserName, SenderTitle, Encoding.UTF8);
                mail.To.Add(new MailAddress(to));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = Port;
                smtp.Credentials = new NetworkCredential(UserName, Password);
                smtp.EnableSsl = UseSSL;

                smtp.Send(mail);
                return true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public async Task SendAsync(string to, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(UserName, SenderTitle, Encoding.UTF8);
                mail.To.Add(new MailAddress(to));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = Port;
                smtp.Credentials = new NetworkCredential(UserName, Password);
                smtp.EnableSsl = UseSSL;

                smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                /*
                 * To
                 * در اینجا یک توکن هست که هر اتفاقی برای ایمیل رخ بده
                 * میگه این توکن مثلا ارسال شد
                 * این توکن موفق به ارسال نشد
                 * که ما توکن ایمیل کاربر در نظر گرفتیم هر اتفاقی
                 * برای ایمیل افتاد ما بفهمیم کدوم ایمیل چی شده
                 * ارسال شده یا نشده چون در آخر توکن برای ما برمیگردونه
                 */
                smtp.SendAsync(mail, to);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string Token = (string)e.UserState;
                if (e.Cancelled)
                {

                }
                else if (e.Error != null)
                {
                    throw new Exception($"Token: [{Token}], Errors: [{e.Error.Message}]", e.Error);
                }
                else
                {
                    // Success
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }


    }
}
