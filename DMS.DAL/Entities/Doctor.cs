using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Entities
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public int? ShiftId { get; set; }
        [ForeignKey("ShiftId")]
        public Shift Shift { get; set; }
    }
}
