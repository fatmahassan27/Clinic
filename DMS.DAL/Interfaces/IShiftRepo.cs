using DMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.Interfaces
{
    public interface IShiftRepo :IGenericRepo<Shift>
    {

        Task<Shift> GetShiftByDocId(int id);
       
    }
}
