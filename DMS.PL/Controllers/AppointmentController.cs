using DMS.BLL.Interfaces;
using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMS.PL.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IDoctorService doctorService;
        private readonly IPatientService patientService;

        public AppointmentController(IAppointmentService appointmentService,IDoctorService doctorService , IPatientService patientService) 
        {
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appointments = await appointmentService.GetAll();
            return View(appointments);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var doctors = await doctorService.GetAll();
            var patients = await patientService.GetAll();
            ViewBag.Doctors = new SelectList(doctors , "Id","Name");
            ViewBag.Patients = new SelectList(patients, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentVM appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await appointmentService.Create(appointment);
                    return RedirectToAction(nameof(Index));

                }
                var doctors = await doctorService.GetAll();
                ViewBag.Doctors = new SelectList(doctors, "Id", "Name");
                var patients = await patientService.GetAll();
                ViewBag.Patients = new SelectList(patients, "Id", "Name");
                return View(appointment);

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the user.");

            }
            var retrydoctors = await doctorService.GetAll();
            ViewBag.Doctors = new SelectList(retrydoctors, "Id", "Name");
            var repatients = await patientService.GetAll();
            ViewBag.Patients = new SelectList(repatients, "Id", "Name");
            return View(appointment);


        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await doctorService.GetAll();
            return Json(doctors);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}
