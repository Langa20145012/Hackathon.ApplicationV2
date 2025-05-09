using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Infrustructure.Data
{   
    public class EmailLogic
    {
        private int _port;
        private string _server;
        private string _username;
        private string _password;
        private bool _IsHtml;
        public EmailLogic(EmailSettings settings)
        {
            _port = settings.SMTP_Port;
            _server = settings.SMTP_ServerName;
            _password = settings.Password;
            _username = settings.Username;
            _IsHtml = settings.IsHtmlMessage;
        }
        public bool SendEmail(EmailMessage message)
        {
            try
            {
                foreach (var address in message.Recipients)
                {
                    MailMessage Message = new MailMessage(_username, address);
                    Message.Body = message.Body;
                    Message.Subject = message.Subject;
                    Message.IsBodyHtml = _IsHtml;

                    if (message != null && message.Attachments != null)
                    {
                        foreach (var file in message.Attachments)
                        {
                            Attachment att = new Attachment(new MemoryStream(file.FileContent), file.Filename);
                            Message.Attachments.Add(att);
                        }
                    }
                    SmtpClient client = new SmtpClient(_server, _port);
                    client.EnableSsl = false;
                    client.Credentials = new NetworkCredential(_username, _password);
                    client.Send(Message);

                }
                return true;
            }
            catch (Exception ex)
            {
                string exc = ex.ToString();
                throw;
            }
        }
    }

    public class EmailMessage
    {
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<EmailAttachedment> Attachments { get; set; }
    }
    public class EmailSettings
    {
        public string SMTP_ServerName { get; set; }
        public int SMTP_Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsHtmlMessage { get; set; }
    }
    public class EmailAttachedment
    {
        public string Filename { get; set; }
        public byte[] FileContent { get; set; }
    }
}
