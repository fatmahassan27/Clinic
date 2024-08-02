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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AppointmentService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Create(AppointmentVM appointmentVM)
        {
            var data = mapper.Map<Appointment>(appointmentVM);
            await unitOfWork.AppointmentRepo.CreateAsync(data);
            await unitOfWork.saveAsync();
        }

        public  async Task<IEnumerable<AppointmentVM>> GetAll()
        {
            var data = await unitOfWork.AppointmentRepo.GetAll();
            var appointments = mapper.Map<IEnumerable<AppointmentVM>>(data);
            return appointments;
        }

        public async Task<IEnumerable<AppointmentVM>> GetAllByDocId(int id)
        {
            var data = await unitOfWork.AppointmentRepo.GetAllByDocId(id);
            var appointments = mapper.Map<IEnumerable<AppointmentVM>>(data);
            return appointments;
        }

        public async Task<IEnumerable<AppointmentVM>> GetTodaysAppointmentsByDoctorId(int doctorId)
        {
            var today = DateTime.Today;
            var data = await unitOfWork.AppointmentRepo.GetAllByDocIdAndDateAsync(doctorId, today);
            var appointments = mapper.Map<IEnumerable<AppointmentVM>>(data);
            return appointments;
        }
    }
}
