using DMS.BLL.Interfaces;
using DMS.BLL.Services;
using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace DMS.PL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;
        private readonly IAppointmentService appointmentService;
        private readonly IShiftService shiftService;

        public DoctorController(IDoctorService doctorService,IAppointmentService appointmentService,IShiftService shiftService)
        {
            this.doctorService = doctorService;
            this.appointmentService = appointmentService;
            this.shiftService = shiftService;
        }

		[HttpGet]
		public async Task<IActionResult> GetDoctors()
		{
            try
            {
                var doctors = await doctorService.GetAll();
                var shifts = await shiftService.GetAll();
                return View(doctors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while retrieving the list of doctors.");
                return View("Error");
            }
        }

		[HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            try
            {
                var doctor = await doctorService.GetById(id);
                if (doctor == null)
                {
                    return NotFound();
                }

                return View(doctor);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while showing data");

            }
            return NotFound();

        }
        [HttpGet]
        public  async Task<IActionResult> Create()
        {
            var shifts = await shiftService.GetAll();
            ViewBag.Shifts = new SelectList(shifts, "Id" ,"DisplayShift" );
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorVM model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await doctorService.Create(model);
                    return RedirectToAction(nameof(GetDoctors));
                }
                var shifts = await shiftService.GetAll();
                ViewBag.Shifts = new SelectList(shifts, "Id" ,"DisplayShift");

                return View(model);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the user.");

            }
            return View(model);

        }



        public async Task<IActionResult> TodaysAppointments(int id)
        {
            try
            {
                ViewBag.DoctorId = id;
                TempData["DoctorId"] = id;
                var appointments = await appointmentService.GetTodaysAppointmentsByDoctorId(id);
                return View(appointments);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while retrieving data");

            }
            return NoContent();

        }
        [HttpGet]
        public IActionResult AppointmentsByDateRange()
        {
            var model = new AppointmentsByDateRangeVM();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AppointmentsByDateRange(AppointmentsByDateRangeVM model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (TempData["DoctorId"] !=null)
                    {
                        model.DoctorId = (int)TempData["DoctorId"];
                    }
                        model.Appointments = await appointmentService.GetAppointmentsByDateRange(model.DoctorId, model.DateFrom, model.DateTo);
                        return View(model);
                    
                }
               
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while retrieving data");
                return View("Error");
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments(int id)
        {
            var appointments = await appointmentService.GetTodaysAppointmentsByDoctorId(id);
            ViewBag.DoctorId = id;
            return View(appointments);
        }

    }
}
