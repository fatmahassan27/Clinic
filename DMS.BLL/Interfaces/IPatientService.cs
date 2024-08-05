using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BLL.Interfaces
{
    public interface IPatientService
    {
        Task Create(PatientVM patient);
        Task<IEnumerable<PatientVM>> GetAll();
        Task<PatientVM> GetById(int id);
        Task<bool> Exists(int id);
        Task<int?> GetPatientIdByNameAsync(string name);



    }
}
