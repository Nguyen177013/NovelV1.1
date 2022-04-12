using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;

namespace Common
{
    public class MailHelper
    {
        public void SendMail(string toEmailAddress,string subject,string content)
        {
            var FromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var FromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var FromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var SMTPHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var SMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            var enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

            string body = content;
            MailMessage message = new MailMessage(new MailAddress(FromEmailAddress, FromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(FromEmailAddress,FromEmailPassword);
            client.Host = SMTPHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(SMTPPort) ? Convert.ToInt32(SMTPPort) : 0;
            client.Send(message);

        }
    }
}
