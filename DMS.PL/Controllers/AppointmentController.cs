using DMS.BLL.Interfaces;
using DMS.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMS.PL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IDoctorService doctorService;

        public AppointmentController(IAppointmentService appointmentService,IDoctorService doctorService) 
        {
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var doctors = await doctorService.GetAll();
            ViewBag.Doctors = new SelectList(doctors , "Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentVM appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await appointmentService.CreateAsync(appointment);
                    return RedirectToAction(nameof(Create));

                }
                var doctors = await doctorService.GetAll();
                ViewBag.Doctors = new SelectList(doctors, "Id", "Name");
                return View(appointment);

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the user.");

            }
            var retrydoctors = await doctorService.GetAll();
            ViewBag.Doctors = new SelectList(retrydoctors, "Id", "Name");
            return View(appointment);


        }


        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await doctorService.GetAll();
            return Json(doctors);
        }

    }
}
