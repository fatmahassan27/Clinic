﻿using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Interfaces
{
    public interface IAppointmentRepo
    {
        Task CreateAsync(Appointment appointment);
    }
}
