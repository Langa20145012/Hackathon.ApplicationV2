using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;

namespace Hackathon.Application.BusinessRules.Common.Interfaces
{
    public interface IDocumentRepository: IRepository<Document>
    {
        Document Update(Document entity);
    }
}
