using Hackathon.Application.BusinessRules.Contract;
using Hackathon.Application.BusinessRules.Services.Interface;
using Hackathon.Application.Infrustructure.Helper;
using Hackathon.Application.Models.Entities;
using Hackathon.Application.Models.MV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Infrustructure.Emails
{
    public class EmailServiceClient
    {
        private readonly IEmailService _emailService;
        private readonly IMatterService _MatterService;
        private readonly IDocumentService _documentService;

        public EmailServiceClient(IEmailService emailService, IMatterService MatterService, IDocumentService documentService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _MatterService = MatterService ?? throw new ArgumentNullException( nameof(MatterService));
            _documentService = documentService ?? throw new ArgumentNullException(nameof(_documentService));
        }

        /// <summary>
        /// Sends a text message using the email service
        /// </summary>
        /// <param name="cellNumber">The recipient's cell number</param>
        /// <param name="messageText">The message content</param>
        /// <returns>True if the message was sent successfully</returns>
        public bool SendTextMessage(string cellNumber, string messageText)
        {
            if (string.IsNullOrEmpty(cellNumber))
                throw new ArgumentNullException(nameof(cellNumber));

            if (string.IsNullOrEmpty(messageText))
                throw new ArgumentNullException(nameof(messageText));

            var message = new TextMessage
            {
                Cellnumber = cellNumber,
                Message = messageText
            };

            return _emailService.SendTextMessage(message);
        }

        /// <summary>
        /// Sends an email asynchronously
        /// </summary>
        /// <param name="body">The email body content</param>
        /// <param name="title">The email subject</param>
        /// <param name="recipient">The email recipient</param>
        /// <returns>A task representing the asynchronous operation, with a boolean result indicating success</returns>
        public async Task<bool> SendEmailAsync(int matterId)
        {
            
            Matter matter = _MatterService.GetMatterById(matterId);
            List<Document> documents = new List<Document>();
            string recipient = "mfalteni@e4.co.za";
            string title = "ADV Complete";
            //documents = _documentService.GetAllDocuments();
            
            string body = EmailHelper.GenerateEmailBody(false, documents, matter.AccountNumber);


            return await _emailService.SendEmailAsync(body, title, recipient);
        }

        /// <summary>
        /// Sends an email to multiple recipients asynchronously
        /// </summary>
        /// <param name="body">The email body content</param>
        /// <param name="title">The email subject</param>
        /// <param name="recipients">List of email recipients</param>
        /// <returns>A task representing the asynchronous operation, with a boolean result indicating success</returns>
        public async Task<bool> SendBulkEmailAsync(string body, string title, List<string> recipients)
        {
            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));

            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            if (recipients == null || recipients.Count == 0)
                throw new ArgumentException("Recipients list cannot be null or empty", nameof(recipients));

            // Send emails to each recipient
            bool allSuccessful = true;
            foreach (var recipient in recipients)
            {
                var result = await _emailService.SendEmailAsync(body, title, recipient);
                if (!result)
                {
                    allSuccessful = false;
                }
            }

            return allSuccessful;
        }
    }
}
