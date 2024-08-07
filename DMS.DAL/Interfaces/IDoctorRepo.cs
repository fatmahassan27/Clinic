﻿using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Interfaces
{
    public interface IDoctorRepo : IGenericRepo<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsWithShifts();
        Task<Doctor> GetByIdWithShift(int id);

    }
}
