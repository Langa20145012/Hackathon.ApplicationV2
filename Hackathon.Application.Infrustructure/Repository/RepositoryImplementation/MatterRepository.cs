using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.BusinessRules.Data;
using Hackathon.Application.Infrustructure.Data;
using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;

namespace Hackathon.Application.Infrustructure.Repository
{
    public class MatterRepository : Repository<Matter>, IMatterRepository
    {
        private readonly ApplicationDbContext db;
        public MatterRepository(ApplicationDbContext _db) : base(_db) { db = _db; }
        public Matter Update(Matter entity)
        {
            entity.Modifieddate = DateTime.Now;
            db.Update(entity);
            db.SaveChanges();
            return entity;
        }
    }
}
