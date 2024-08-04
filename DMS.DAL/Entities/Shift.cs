using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Entities
{
    public class Shift
    {

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();

    }
}
