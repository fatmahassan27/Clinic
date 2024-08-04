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
    public class DoctorRepo : GenericRepo<Doctor> , IDoctorRepo
    {
        private readonly ApplicationDbContext dbcontext;

        public DoctorRepo(ApplicationDbContext dbcontext) :base(dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsWithShifts()
        {
            var doctors = await dbcontext.Doctors.Include(a => a.Shift).ToListAsync();
            return doctors;
        }
        public async Task<Doctor> GetByIdWithShift(int id)
        {
            try
            {
                var doctor = await dbcontext.Doctors.Where(a => a.Id == id).Include(a => a.Shift).FirstOrDefaultAsync();
                return doctor;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
            
        }
    }
}
