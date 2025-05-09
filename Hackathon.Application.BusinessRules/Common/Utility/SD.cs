using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.BusinessRules.Common.Utility
{
    public static class SD
    {
        public const string Role_Applicant = "Applicant";
        public const string Role_Admin = "Admin";        

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusAccepted = "Accepted";
        public const string StatusRejected = "Rejected";
        public const string StatusCompleted = "Completed";
        public const string StatusPartially = "Partially";
    }
}
