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
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DoctorService(IUnitOfWork unitOfWork ,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<DoctorVM>> GetAll()
        {
                var doctors =  await unitOfWork.DoctorRepo.GetAll();
                var doctorsVM = mapper.Map<IEnumerable<DoctorVM>>(doctors);
                return doctorsVM;
        }
    }
}
