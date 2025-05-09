using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.BusinessRules.Data;
using Hackathon.Application.Infrustructure.Data;
using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;

namespace Hackathon.Application.Infrustructure.Repository
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private readonly ApplicationDbContext db;
        public DocumentRepository(ApplicationDbContext _db) : base(_db) { db = _db; }

        public Document Update(Document entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            db.Update(entity);
            db.SaveChanges();
            return entity;
        }
    }
}
