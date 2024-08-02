using DMS.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DMS.PL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IAppointmentService appointmentService;

        public DoctorController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TodaysAppointments(int doctorId)
        {
            var appointments = await appointmentService.GetTodaysAppointmentsByDoctorId(doctorId);
            return View(appointments);
        }
    }
}
