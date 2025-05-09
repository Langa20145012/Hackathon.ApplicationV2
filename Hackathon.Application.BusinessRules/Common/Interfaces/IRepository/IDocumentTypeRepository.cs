using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;

namespace Hackathon.Application.BusinessRules.Common.Interfaces
{
    public interface IDocumentTypeRepository: IRepository<DocumentType>
    {
        DocumentType Update(DocumentType entity);
    }
}
