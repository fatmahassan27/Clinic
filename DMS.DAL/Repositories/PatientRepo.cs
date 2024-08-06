using DMS.DAL.Database;
using DMS.DAL.Entities;
using DMS.DAL.Interfaces;
using DMS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Repositories
{
    public class PatientRepo : GenericRepo<Patient> ,IPatientRepo
    {
        private readonly ApplicationDbContext dbContext;

        public PatientRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Exists(int id)
        {
            return await dbContext.Patients.AnyAsync(p => p.Id == id);
        }

        public  async Task<int?> GetPatientIdByNameAsync(string name)
        {
            var patient = await dbContext.Patients
            .Where(p => p.Name==name)
            .FirstOrDefaultAsync();

            return patient?.Id;
        }
    }
}
