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
                var appointments = await dbContext.Appointments.Include(a=>a.Doctor).Include(p=>p.Patient).Where(a => a.DoctorId == id).ToListAsync();
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
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateRange(int doctorId, DateTime startDate, DateTime endDate)
        {
            return await dbContext.Appointments.Include(a=>a.Patient)
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date >= startDate.Date && a.AppointmentDate.Date <= endDate.Date)
                .ToListAsync();
        }
        public async Task<IEnumerable<Slot>> GetAvailableSlots(int doctorId, DateTime date)
        {
            var appointments = await dbContext.Appointments.Include(a=>a.Patient)
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date)
                .ToListAsync();

            var slots = GenerateSlots(); 
            var occupiedSlots = appointments.Select(a => a.StartTime.ToString("HH:mm")).ToHashSet();
            var availableSlots = slots.Where(slot => !occupiedSlots.Contains(slot.Value)).ToList();

            return availableSlots;
        }
        private List<Slot> GenerateSlots()
        {
            var slots = new List<Slot>();
            var startTime = new TimeSpan(9, 0, 0); 
            var endTime = new TimeSpan(17, 0, 0); 
            var slotDuration = TimeSpan.FromMinutes(30); 

            for (var time = startTime; time < endTime; time += slotDuration)
            {
                var slotTime = time.ToString(@"hh\:mm");
                slots.Add(new Slot { Value = slotTime, Text = slotTime });
            }

            return slots;
        }
    }
}
