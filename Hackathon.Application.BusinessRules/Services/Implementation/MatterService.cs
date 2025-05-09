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
    public class MatterService : IMatterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MatterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateMatter(Matter Matter)
        {
            ArgumentNullException.ThrowIfNull(Matter);

            _unitOfWork.Matter.Add(Matter);
            _unitOfWork.Save();
        }

        public bool DeleteMatter(int id)
        {
            try
            {
                var Matter = _unitOfWork.Matter.Get(u => u.MatterId == id);
                if (Matter != null)
                {
                    _unitOfWork.Matter.Remove(Matter);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException($"Matter with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public IEnumerable<Matter> GetAllMatter()
        {
            return _unitOfWork.Matter.GetAll();
        }

        public Matter GetMatterById(int id)
        {
            return _unitOfWork.Matter.Get(u => u.MatterId == id);
        }

        public void UpdateMatter(Matter Matter)
        {
            ArgumentNullException.ThrowIfNull(Matter);

            _unitOfWork.Matter.Update(Matter);
            _unitOfWork.Save();
        }

		public Matter Initialize(int id)
		{
			var entity = GetMatterById(id);
			return _unitOfWork.Matter.Initialize(entity);
		}

	}
}
