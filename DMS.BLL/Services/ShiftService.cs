using AutoMapper;
using DMS.BLL.Interfaces;
using DMS.BLL.ViewModels;
using DMS.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShiftService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ShiftVM>> GetAll()
        {
            var data = await unitOfWork.ShiftRepo.GetAllAsync();
            var shifts = mapper.Map<IEnumerable<ShiftVM>>(data);
            return shifts;
        }

        public Task<ShiftVM> GetShiftByDoctorId(int doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
