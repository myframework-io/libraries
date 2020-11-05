using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Emails
{
    public class EmailManagement : IEmailManagement
    {
        private readonly EmailOptions options;

        public EmailManagement(IOptions<EmailOptions> options) => this.options = options.Value;

        public async Task SendEmailAsync(string email, string subject, string message, List<string> cc = null, List<string> bcc = null)
        {
            var mail = new MailMessage() { From = new MailAddress(options.FromEmail, options.FromName) };

            mail.To.Add(new MailAddress(email));

            mail.Subject = options.SubjectPrefix + subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            if (cc != null)
                cc.ForEach(it => mail.CC.Add(it));

            if (bcc != null)
                bcc.ForEach(it => mail.Bcc.Add(it));

            using (var smtp = new SmtpClient(options.Host, options.Port))
            {
                if (!string.IsNullOrWhiteSpace(options.NetworkCredentialUserName))
                    smtp.Credentials = new NetworkCredential(options.NetworkCredentialUserName, options.NetworkCredentialPassWord);

                smtp.EnableSsl = options.EnableSsl;
                await smtp.SendMailAsync(mail);
            }
        }

        public async Task SendEmailAsync(string email, string subject, string message, Stream stream, string fileName, List<string> cc = null, List<string> bcc = null)
        {
            var mail = new MailMessage() { From = new MailAddress(options.FromEmail, options.FromName) };

            mail.To.Add(new MailAddress(email));

            mail.Subject = options.SubjectPrefix + subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            mail.Attachments.Add(new Attachment(stream, fileName));

            if (cc != null)
                cc.ForEach(it => mail.CC.Add(it));

            if (bcc != null)
                bcc.ForEach(it => mail.Bcc.Add(it));

            using (var smtp = new SmtpClient(options.Host, options.Port))
            {
                smtp.Credentials = new NetworkCredential(options.NetworkCredentialUserName, options.NetworkCredentialPassWord);
                smtp.EnableSsl = options.EnableSsl;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}