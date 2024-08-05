using DMS.DAL.Entities;
using DMS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Interfaces
{
    public interface IAppointmentRepo : IGenericRepo<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task<IEnumerable<Appointment>> GetAllByDocId(int id);
        Task<IEnumerable<Appointment>> GetAllByDocIdAndDateAsync(int doctorId,DateTime date);
        Task<IEnumerable<Appointment>> GetAppointmentsByDateRange(int doctorId, DateTime startTime, DateTime endTime);
        Task<IEnumerable<Slot>> GetAvailableSlots(int doctorId, DateTime date);

    }
}
