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
    }
}
