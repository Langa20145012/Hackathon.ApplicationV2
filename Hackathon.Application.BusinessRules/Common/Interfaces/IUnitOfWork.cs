using Hackathon.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.BusinessRules.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IMatterRepository Matter { get; }
        IDocumentRepository Document { get; }
        IDocumentTypeRepository DocumentType { get; }
        IApplicationUserRepository User { get; }
        void Save();
    }
}
