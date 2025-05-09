using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.BusinessRules.Services.Interface
{
    public interface IDocumentTypeService
    {
        IEnumerable<DocumentType> GetAllDocumentType();
        void CreateDocumentType(DocumentType DocumentType);
        void UpdateDocumentType(DocumentType DocumentType);
        DocumentType GetDocumentTypeById(int id);
        bool DeleteDocumentType(int id);
    }
}