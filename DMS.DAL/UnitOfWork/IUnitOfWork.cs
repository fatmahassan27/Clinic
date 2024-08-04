using DMS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAppointmentRepo AppointmentRepo { get; }
        IDoctorRepo DoctorRepo { get; }
        IPatientRepo PatientRepo { get; }
        IShiftRepo ShiftRepo { get; }
        Task<int> saveAsync();

    }
}
