using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.BusinessRules.Services.Interface
{
    public interface IDocumentService
    {
        IEnumerable<Document> GetAllDocument();
        void CreateDocument(Document Document);
        void UpdateDocument(Document Document);
        Document GetDocumentById(int id);
        bool DeleteDocument(int id);
    }
}