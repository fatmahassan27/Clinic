using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.DAL.CustomValidation;

namespace DMS.BLL.ViewModels
{
    public class PatientVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long? SSN { get; set; }
        [BirthdayValidate] // Custom Validation
        public DateTime BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
