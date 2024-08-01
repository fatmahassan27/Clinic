using DMS.DAL.Database;
using DMS.DAL.Interfaces;
using DMS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private IAppointmentRepo appointmentRepo;
        private IDoctorRepo doctorRepo;

        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public IAppointmentRepo AppointmentRepo
        {
            get
            {
                return appointmentRepo??=new AppointmentRepo(dbContext);
            }
        }
        public IDoctorRepo DoctorRepo
        {
            get
            {
                return doctorRepo ??= new DoctorRepo(dbContext);
            }
        }

        public async Task<int> saveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
