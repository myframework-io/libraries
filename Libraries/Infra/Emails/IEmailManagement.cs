using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Myframework.Libraries.Infra.Emails
{
    public interface IEmailManagement
    {
        Task SendEmailAsync(string email, string subject, string message, List<string> cc = null, List<string> bcc = null);
        Task SendEmailAsync(string email, string subject, string message, Stream stream, string fileName, List<string> cc = null, List<string> bcc = null);
    }
}