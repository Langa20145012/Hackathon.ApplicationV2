using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.BusinessRules.Data;
using Hackathon.Application.Infrustructure.Data;
using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;

namespace Hackathon.Application.Infrustructure.Repository
{
    public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
    {
        private readonly ApplicationDbContext db;
        public DocumentTypeRepository(ApplicationDbContext _db) : base(_db) { db = _db; }

        public DocumentType Update(DocumentType entity)
        {
            entity.Modifieddate = DateTime.Now;
            db.Update(entity);
            db.SaveChanges();
            return entity;
        }
    }
}
