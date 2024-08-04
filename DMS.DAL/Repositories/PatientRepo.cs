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
    public class PatientRepo : GenericRepo<Patient> ,IPatientRepo
    {
        private readonly ApplicationDbContext dbContext;

        public PatientRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
