using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.ViewModels
{
    public class AppointmentsByDateRangeVM
    {
        public int DoctorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public IEnumerable<AppointmentVM> Appointments { get; set; } = new List<AppointmentVM>();
    }
}
