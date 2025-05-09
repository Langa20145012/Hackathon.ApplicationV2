using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.BusinessRules.Services.Interface;
using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.BusinessRules.Services.Implementation
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateDocument(Document Document)
        {
            ArgumentNullException.ThrowIfNull(Document);

            _unitOfWork.Document.Add(Document);
            _unitOfWork.Save();
        }

        public bool DeleteDocument(int id)
        {
            try
            {
                var Document = _unitOfWork.Document.Get(u => u.DocumentId == id);

                if (Document != null)
                {

                    _unitOfWork.Document.Remove(Document);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException($"Document with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public IEnumerable<Document> GetAllDocument()
        {
            return _unitOfWork.Document.GetAll();
        }

        public Document GetDocumentById(int id)
        {
            return _unitOfWork.Document.Get(u => u.DocumentId == id);
        }

        public void UpdateDocument(Document Document)
        {
            ArgumentNullException.ThrowIfNull(Document);

            _unitOfWork.Document.Update(Document);
            _unitOfWork.Save();
        }
    }
}
