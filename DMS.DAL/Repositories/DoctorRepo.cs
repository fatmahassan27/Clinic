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
    public class DoctorRepo : IDoctorRepo
    {
        private readonly ApplicationDbContext dbcontext;

        public DoctorRepo(ApplicationDbContext dbcontext) 
        {
            this.dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Doctor>> GetAll()
        {
            try
            {
                var Doctors = await dbcontext.Doctors.ToListAsync();
                if(Doctors==null)
                {
                    await Console.Out.WriteLineAsync("No Data To Show");

                }
                return Doctors;
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}
