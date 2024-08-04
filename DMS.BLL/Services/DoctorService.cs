using AutoMapper;
using DMS.BLL.Interfaces;
using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
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
                var doctors =  await unitOfWork.DoctorRepo.GetDoctorsWithShifts();
                var doctorsVM = mapper.Map<IEnumerable<DoctorVM>>(doctors);
                return doctorsVM;
        }

        public async Task<DoctorVM> GetById(int id)
        {
            var doctor = await unitOfWork.DoctorRepo.GetByIdWithShift(id);
            var doctorVM = mapper.Map<DoctorVM>(doctor);
            return doctorVM;
        }

        public async Task Create(DoctorVM doctor)
        {
            var data = mapper.Map<Doctor>(doctor);
            await unitOfWork.DoctorRepo.CreateAsync(data);
            await unitOfWork.saveAsync();

        }
    }
}
