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
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext dbContext;

        public PatientRepo(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Patient patient)
        {
            await dbContext.Patients.AddAsync(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            try
            {
                var patients = await dbContext.Patients.ToListAsync();
                if(patients == null)
                {
                    await Console.Out.WriteLineAsync("No Data To Show");

                }
                return patients;
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            try
            {
                var patient = await dbContext.Patients.Where(a => a.Id == id).FirstOrDefaultAsync();
                if(patient == null)
                {
                    await Console.Out.WriteLineAsync("No Data To Show");
                }
                return patient;

            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}
