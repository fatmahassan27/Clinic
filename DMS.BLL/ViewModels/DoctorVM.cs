using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.ViewModels
{
    public class DoctorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int?  ShiftId { get; set; }
        public ShiftVM? shift {  get; set; }
    }
}
