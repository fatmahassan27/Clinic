using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task Create(AppointmentVM appointmentVM);
        Task<IEnumerable<AppointmentVM>> GetAll();
        Task<AppointmentVM> GetById(int id);
        Task UpdateAsync(AppointmentVM appointmentVM);

        Task<IEnumerable<AppointmentVM>> GetAllByDocId(int id);
        Task<IEnumerable<AppointmentVM>> GetTodaysAppointmentsByDoctorId(int doctorId);
        Task<IEnumerable<AppointmentVM>> GetAppointmentsByDateRange(int doctorId, DateTime StartDate, DateTime EndDate);
        Task<IEnumerable<SlotsVM>> GetAvailableSlots(int doctorId, DateTime date);

        Task Delete(int id);


    }
}
