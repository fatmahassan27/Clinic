using DMS.DAL.Database;
using DMS.DAL.Entities;
using DMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Repositories
{
    public class AppointmentRepo : GenericRepo<Appointment> , IAppointmentRepo
    {
        private readonly ApplicationDbContext dbContext;

        public AppointmentRepo(ApplicationDbContext dbContext)  :base (dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Appointment>> GetAll()
        {
            try
            {
                var appointments = await dbContext.Appointments.Include(a => a.Doctor).Include(p => p.Patient ).ToListAsync();
                if (appointments == null)
                {
                    await Console.Out.WriteLineAsync("No Data To Show");
                }
                return appointments;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
        public async Task<IEnumerable<Appointment>> GetAllByDocId(int id)
        {
            try
            {
                var appointments = await dbContext.Appointments.Include(a=>a.Doctor).Where(a => a.DoctorId == id).ToListAsync();
                if(appointments==null)
                {
                    await Console.Out.WriteLineAsync("No Data To Show");
                }
                return appointments;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
        public async Task<IEnumerable<Appointment>> GetAllByDocIdAndDateAsync(int doctorId,DateTime date)
        {
            return await dbContext.Appointments.Include(p=>p.Patient)
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date)
                .ToListAsync();
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateRange(int doctorId, DateTime startTime, DateTime endTime)
        {
            return await dbContext.Appointments
                .Where(a => a.DoctorId == doctorId && a.StartTime >= startTime && a.EndTime <= endTime)
                .ToListAsync();
        }
    }
}
