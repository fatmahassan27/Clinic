using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.ViewModels
{
    public class AppointmentVM
    {
        public DoctorVM Doctor { get; set; }
        public PatientVM Patient { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } //confirm - cancelled


    }
}
