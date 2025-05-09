
using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;

namespace Hackathon.Application.BusinessRules.Common.Interfaces
{
    public interface IMatterRepository: IRepository<Matter>
    {
        Matter Initialize(Matter matterId);
        Matter Update(Matter entity);
    }
}
