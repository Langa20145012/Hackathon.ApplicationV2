using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Hackathon.Application.Models.MV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Hackathon.Application.BusinessRules.Contract;

namespace Hackathon.Application.Infrustructure.Data
{
    public class EmailService : IEmailService
    {
        private readonly string _sendGridKey;
        private readonly string _UsernameKey;
        private readonly string _PasswordKey;

		public string Username { get; set; }
		public string Password { get; set; }
		public string Port { get; set; }
		public string Host { get; set; }
		
        public EmailService(IConfiguration configuration)
        {
            _sendGridKey = configuration["SendGrid:Key"];
            _UsernameKey = configuration["SMS:Username"];
            _PasswordKey = configuration["SMS:Password"];

            Username = configuration.GetValue<string>("Mail:Username");
            Password = configuration.GetValue<string>("Mail:Password");
            Port = configuration.GetValue<string>("Mail:Port");
            Host = configuration.GetValue<string>("Mail:Host");
        }

		public bool SendTextMessage(TextMessage message)
        {
            try
            {
                string url = string.Format("http://www.mymobileapi.com/api5/http5.aspx?Type=sendparam&username={0}&password={1}&numto={2}&data1={3}", 
                    _UsernameKey,
                    _PasswordKey, 
                    message.Cellnumber, 
                    message.Message);

                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "POST";
                using (Stream s = req.GetRequestStream())
                {
                    string postData = "a";
                    byte[] bPostData = System.Text.ASCIIEncoding.UTF8.GetBytes(postData);
                    s.Write(bPostData, 0, bPostData.Length);
                    s.Flush();
                    s.Close();
                    s.Dispose();
                    WebResponse resp = req.GetResponse();
                    resp.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Shabangu catched the folowing error while trying to send text message: " + ex.Message, ex);
            }
        }

		public Task<bool> SendEmailAsync(string Body, string Title, string Recipient)
		{
			var msg = new EmailMessage();

			var AttachmentsList = new List<EmailAttachedment>();
			msg.Recipients = new List<string>() { Recipient };

			msg.Body = Body;
			msg.Subject = Title;

			var settings = new EmailSettings()
			{
				IsHtmlMessage = true,
				Password = Password,
				SMTP_Port = Convert.ToInt32(Port),
				SMTP_ServerName = Host,
				Username = Username
			};

			new EmailLogic(settings).SendEmail(msg);
			return Task.FromResult(true);
		}
	}
}
