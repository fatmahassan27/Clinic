using DMS.DAL.Database;
using DMS.DAL.Entities;
using DMS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext dbContext;

        public AppointmentRepo(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Appointment appointment)
        {
            await dbContext.Appointments.AddAsync(appointment);
        }
    }
}
