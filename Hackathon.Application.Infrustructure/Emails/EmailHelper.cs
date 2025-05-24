using Hackathon.Application.BusinessRules.Contract;
using Hackathon.Application.Infrustructure.Data;
using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Infrustructure.Helper
{
    public enum DocumentStatus
    {
        Accepted,
        Rejected
    }
    public static class EmailHelper
    {
        public static string GenerateEmailBody(bool isSuccess, List<Document> documents, string accountNumber, string processName = "ADV Process", string ADVPercentageMessage = null)
        {
            StringBuilder sb = new StringBuilder();

            // Start HTML document
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; line-height: 1.6; }");
            sb.AppendLine(".header { padding: 20px; text-align: center; }");
            sb.AppendLine(".Accepted { color: #2e7d32; }");
            sb.AppendLine(".Rejected { color: #c62828; }");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; margin-top: 20px; }");
            sb.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            sb.AppendLine("th { background-color: #f2f2f2; }");
            sb.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
            sb.AppendLine(".status-cell { font-weight: bold; }");
            sb.AppendLine(".error-message { color: #c62828; font-style: italic; }");
            sb.AppendLine(".success-message { color: #2e7d32; font-style: italic; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");

            // Header section
            sb.AppendLine("<div class='header'>");
            sb.AppendLine($"<h2 >{processName} Completed for Account Number: {accountNumber}</h2>");
            if (isSuccess)
            {
                sb.AppendLine($"<h2 class='Accepted'>{processName} Completed.</h2>");
                sb.AppendLine("<p>All documents have been processed.</p>");
            }
            else
            {
                sb.AppendLine($"<h2 class='failure'>{processName} Completed With Errors</h2>");
                sb.AppendLine("<p>Some documents failed during processing. Please review the details below.</p>");
            }
            sb.AppendLine("</div>");



            // Document table
            sb.AppendLine("<h3>Document Processing Results</h3>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th>Document Name</th>");
            sb.AppendLine("<th>Document ID</th>");
            sb.AppendLine("<th>Status</th>");
            sb.AppendLine("<th>ADV Results</th>");
            sb.AppendLine("</tr>");

            foreach (var doc in documents)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{doc.FileName}</td>");
                sb.AppendLine($"<td>{doc.DocumentId}</td>");
                sb.AppendLine($"<td class='status-cell {doc.Status}'>{doc.Status}</td>");
                if (doc.Status == DocumentStatus.Rejected.ToString())
                {
                    sb.AppendLine($"<td class='error-message'>{doc.ADVPercentage}</td>");
                }
                else
                {
                    sb.AppendLine($"<td class='success-message'>{doc.ADVPercentage}</td>");
                }

                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");

            // Summary section
            int successCount = documents.FindAll(d => d.Status == DocumentStatus.Accepted.ToString()).Count;
            int failedCount = documents.FindAll(d => d.Status == DocumentStatus.Rejected.ToString()).Count;

            sb.AppendLine("<div style='margin-top: 20px;'>");
            sb.AppendLine("<h3>Summary</h3>");
            sb.AppendLine("<ul>");
            sb.AppendLine($"<li><span class='success'>Successful:</span> {successCount}</li>");
            if (failedCount > 0)
            {
                sb.AppendLine($"<li><span class='failure'>Failed:</span> {failedCount}</li>");
            }
            sb.AppendLine($"<li>Total: {documents.Count}</li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");

            // Footer
            sb.AppendLine("<div style='margin-top: 30px; font-size: 12px; color: #666; border-top: 1px solid #eee; padding-top: 10px;'>");
            sb.AppendLine($"<p>This is an automated message generated on {DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>");
            sb.AppendLine("</div>");

            // Close HTML document
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
