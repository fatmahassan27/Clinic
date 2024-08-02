using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.ViewModels
{
    public class AppointmentVM
    {
        public int Id { get; set; }
        [Required]
        public int PatientId {  get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        [Required]
        public int DoctorId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        public string Status { get; set; } //confirm - cancelled
    }
}
