using AutoMapper;
using DMS.BLL.Interfaces;
using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using DMS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PatientService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Create(PatientVM patient)
        {
            var data = mapper.Map<Patient>(patient);
            await unitOfWork.PatientRepo.CreateAsync(data);
            await unitOfWork.saveAsync();

        }

        public async Task<IEnumerable<PatientVM>> GetAll()
        {
            var data = await unitOfWork.PatientRepo.GetAllAsync();
            var patients = mapper.Map<IEnumerable<PatientVM>>(data);
            return patients;
        }

        public async Task<PatientVM> GetById(int id)
        {
            var data = await unitOfWork.PatientRepo.GetByIdAsync(id);
            var patient = mapper.Map<PatientVM>(data);
            return patient;
        }
        public async Task<bool> Exists(int id)
        {
            return await unitOfWork.PatientRepo.Exists(id);
        }

        public async Task<int?> GetPatientIdByNameAsync(string name)
        {
            var data = await unitOfWork.PatientRepo.GetPatientIdByNameAsync(name);
           // var patient = mapper.Map<PatientVM>(data);
            return data;

        }
    }
}
