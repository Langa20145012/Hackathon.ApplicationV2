using Hackathon.Application.Models;
using Hackathon.Application.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.BusinessRules.Services.Interface
{
    public interface IMatterService
    {
        IEnumerable<Matter> GetAllMatter();
        void CreateMatter(Matter Matter);
        void UpdateMatter(Matter Matter);
        Matter GetMatterById(int id);
        bool DeleteMatter(int id);

		Matter Initialize(int id);
	}
}