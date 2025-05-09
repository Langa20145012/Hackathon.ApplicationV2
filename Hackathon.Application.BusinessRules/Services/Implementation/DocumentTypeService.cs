using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.BusinessRules.Services.Interface;
using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.BusinessRules.Services.Implementation
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DocumentTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateDocumentType(DocumentType DocumentType)
        {
            ArgumentNullException.ThrowIfNull(DocumentType);

            _unitOfWork.DocumentType.Add(DocumentType);
            _unitOfWork.Save();
        }

        public bool DeleteDocumentType(int id)
        {
            try
            {
                var DocumentType = _unitOfWork.DocumentType.Get(u => u.DocumentTypeId == id);
                if (DocumentType != null)
                {
                    _unitOfWork.DocumentType.Remove(DocumentType);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException($"DocumentType with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public IEnumerable<DocumentType> GetAllDocumentType()
        {
            return _unitOfWork.DocumentType.GetAll();
        }

        public DocumentType GetDocumentTypeById(int id)
        {
            return _unitOfWork.DocumentType.Get(u => u.DocumentTypeId == id);
        }

        public void UpdateDocumentType(DocumentType DocumentType)
        {
            ArgumentNullException.ThrowIfNull(DocumentType);

            _unitOfWork.DocumentType.Update(DocumentType);
            _unitOfWork.Save();
        }
	}
}
