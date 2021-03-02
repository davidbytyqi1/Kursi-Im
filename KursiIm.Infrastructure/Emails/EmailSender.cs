using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using KursiIm.Domain.Administrations;
using KursiIm.Domain.Logs;
using KursiIm.Infrastructure.Logs;

namespace KursiIm.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        //private readonly ISettingsDictonaryRepository _settingsDictonaryRepository;
        private readonly ISaveLog _saveLog;

        public EmailSender(ISaveLog saveLog)
        {
            //_settingsDictonaryRepository = settingsDictonaryRepository;
            _saveLog = saveLog;
        }

        public Task SendEmailAsync(EmailInfo emailInfo)
        {
            Execute(emailInfo).Wait();
            return Task.CompletedTask;
        }

        public async Task<string> Execute(EmailInfo emailInfo)
        {
            //var settings = _settingsDictonaryRepository.GetSettingsDictionariesByKeyAndType(1, null).ToList();
            var settings = new Dictionary<string, string>();
            var emailSettings = new EmailSettings
            {
                //Domain = settings.Where(t => t.Key == "Server").FirstOrDefault().ValueSq,
                //Port = int.Parse(settings.Where(t => t.Key == "Port").FirstOrDefault().ValueSq),
                //EamilUsername = settings.Where(t => t.Key == "From").FirstOrDefault().ValueSq,
                //EmailPassword = settings.Where(t => t.Key == "Password").FirstOrDefault().ValueSq,
                //EmailSignature = settings.Where(t => t.Key == "EmailSignature").FirstOrDefault().ValueSq,
                //FromEmail = settings.Where(t => t.Key == "From").FirstOrDefault().ValueSq,
                //CCEmail = settings.Where(t => t.Key == "CC").FirstOrDefault().ValueSq,
                //BCCEmail = settings.Where(t => t.Key == "BCC").FirstOrDefault().ValueSq,
                //ToEmail = settings.Where(t => t.Key == "To").FirstOrDefault().ValueSq,
                Subject = ""
            };

            string fromEmail = emailSettings.FromEmail;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Subject = emailInfo.Subject;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.Body = emailInfo.Body.Replace("{[EmailSignature]}", emailSettings.EmailSignature);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            if (emailInfo.HasAttach)
                foreach (var item in emailInfo.Attachments)
                {
                    var types = GetAttachContentType(emailInfo.AttachContentType);
                    Stream stream = new MemoryStream(item);
                    mail.Attachments.Add(new Attachment(stream, types.Item2, types.Item1));
                }

            foreach (var item in emailInfo.ToEmails)
            {
                if (IsValidEmail(item))
                    mail.Bcc.Add(item);
            }

            if (emailInfo.CCEmails != null)
                foreach (var item in emailInfo.CCEmails)
                {
                    if (IsValidEmail(item))
                        mail.CC.Add(item);
                }

            try
            {
                using (SmtpClient smtp = new SmtpClient(emailSettings.Domain, emailSettings.Port))
                {
                    smtp.UseDefaultCredentials = false;
                    //smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(emailSettings.EamilUsername, emailSettings.EmailPassword);
                    await smtp.SendMailAsync(mail);
                }

                _saveLog.LogInformation("Email with subject \"" + emailInfo.Subject + "\" on date " + DateTime.Now.ToString(@"dd.MM.yyyy HH:mm:ss"));

            }
            catch (Exception ex)
            {
                _saveLog.LogError(ex, "Failed to sent eamil!");
                return ex.Message;
            }

            return null;

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        Tuple<string, string> GetAttachContentType(string type)
        {
            if (type.ToLowerInvariant().Equals("word"))
                return new Tuple<string, string>("application/msword", "Report.doc");
            else if (type.ToLowerInvariant().Equals("excel"))
                return new Tuple<string, string>("application/vnd.ms-excel", "Report.xls");
            else
                return new Tuple<string, string>("application/pdf", "Report.pdf");
        }
    }
}
