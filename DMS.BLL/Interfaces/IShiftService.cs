using DMS.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.Interfaces
{
    public interface IShiftService
    {
        Task<IEnumerable<ShiftVM>> GetAll();
        Task<ShiftVM> GetShiftByDoctorId(int doctorId);
        Task Create(ShiftVM shift);

    }
}
