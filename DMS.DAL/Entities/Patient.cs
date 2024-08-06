using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.DAL.CustomValidation;

namespace DMS.DAL.Entities
{
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        public long? SSN { get; set; }
        [Required]
        [BirthdayValidate]
        public DateTime BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required,MaxLength(50)]
        public string Address { get; set; }
    }
}
