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
    public class ShiftRepo :GenericRepo<Shift> ,IShiftRepo
    {
        private readonly ApplicationDbContext dbContext;

        public ShiftRepo(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Shift> GetShiftByDocId(int id)
        {
           var shift =  await dbContext.shifts.Include(a => a.Doctors).FirstOrDefaultAsync();
            if (shift == null)
            {
				await Console.Out.WriteLineAsync("No Data To Show");

			}
			return shift;
        }
    }
}
