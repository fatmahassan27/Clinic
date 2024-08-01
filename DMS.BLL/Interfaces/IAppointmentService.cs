﻿using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task CreateAsync(AppointmentVM appointmentVM);

    }
}
