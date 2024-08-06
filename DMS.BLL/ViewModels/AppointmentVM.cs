using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.DAL.CustomValidation;


namespace DMS.BLL.ViewModels
{
    public class AppointmentVM
    {
        public int Id { get; set; }
       
        public string? DoctorName { get; set; }
        [Required]
        public int DoctorId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        [CustomDate]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        public string? Status { get; set; } //confirm - cancelled

        // Patient details
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        [BirthdayValidate]
        public DateTime PatientBirthDate { get; set; }
        public long? PatientSSN {  get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientPhoneNumber { get; set; }


    }
}
