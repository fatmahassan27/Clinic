using DMS.BLL.Interfaces;
using DMS.BLL.Services;
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
            try
            {
                var appointments = await appointmentService.GetAll();
                return View(appointments);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while retrieving appointments.");
                return View(new List<AppointmentVM>());
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateViewData();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentVM appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool patientExists = await patientService.Exists(appointment.PatientId);
                    if (!patientExists)
                    {
                        ModelState.AddModelError("PatientId", "The selected patient does not exist.");
                        return View(appointment);
                    }
                    await appointmentService.Create(appointment);
                    return RedirectToAction(nameof(Index));

                }
                await PopulateViewData();
                return View(appointment);

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the user.");
                await PopulateViewData();
                return View(appointment);

            }
            
        }

      
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var appointment = await appointmentService.GetById(id);
                if (appointment == null)
                {
                    return NotFound();

                }
                await PopulateViewData();
                return View(appointment);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while retrieving the appointment.");
                return RedirectToAction(nameof(Index));
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppointmentVM appointmentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await appointmentService.UpdateAsync(appointmentVM);
                    return RedirectToAction(nameof(Index));
                }

                await PopulateViewData();
                return View(appointmentVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the appointment.");
                return View(appointmentVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await appointmentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the appointment.");
                return RedirectToAction(nameof(Index));
            }
        }

        private async Task PopulateViewData()
        {
            var doctors = await doctorService.GetAll();
            ViewBag.Doctors = new SelectList(doctors, "Id", "Name");
        }

    }
}
