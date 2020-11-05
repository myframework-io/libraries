namespace Myframework.Libraries.Infra.Emails
{
    public class EmailOptions
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string SubjectPrefix { get; set; }

        public string Host { get; set; }
        public int Port { get; set; }
        public string NetworkCredentialUserName { get; set; }
        public string NetworkCredentialPassWord { get; set; }
        public bool EnableSsl { get; set; }
    }
}