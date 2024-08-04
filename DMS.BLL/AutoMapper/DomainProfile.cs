using AutoMapper;
using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile() 
        {
            CreateMap<Appointment, AppointmentVM>();
            CreateMap<AppointmentVM, Appointment>();

           //------------------------------------------------
            CreateMap<Doctor, DoctorVM>();
            CreateMap<DoctorVM, Doctor>();
            //-----------------------------------
            CreateMap<Patient, PatientVM>();
            CreateMap<PatientVM, Patient>();
            //------------------------------------------
            CreateMap<Shift, ShiftVM>();
            CreateMap<ShiftVM, Shift>();
        }
    }
}
