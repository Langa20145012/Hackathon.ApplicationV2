using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.BusinessRules.Data;
using Hackathon.Application.Infrustructure.Data;
using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Infrustructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IApplicationUserRepository User { get; private set; }
        public IMatterRepository Matter { get; private set; }
		public IDocumentRepository Document { get; private set; }
		public IDocumentTypeRepository DocumentType { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;            
            User = new ApplicationUserRepository(_db);
            Matter = new MatterRepository(_db);
            Document = new DocumentRepository(_db);
            DocumentType = new DocumentTypeRepository(_db); 
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
