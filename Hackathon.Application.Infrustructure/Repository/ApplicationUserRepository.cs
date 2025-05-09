using Microsoft.EntityFrameworkCore;
using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.Infrustructure.Data;
using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hackathon.Application.BusinessRules.Data;

namespace Hackathon.Application.Infrustructure.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }      
    }
}
