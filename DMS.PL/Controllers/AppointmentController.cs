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
        public async Task<IActionResult> Create(AppointmentVM model)
        {
            try
            {

                if (model.PatientId == 0)
                {

                    var existingPatientId = await patientService.GetPatientIdByNameAsync(model.PatientName);

                    if (existingPatientId.HasValue)
                    {
                        model.PatientId = existingPatientId.Value;
                    }
                    else
                    {
                        var newPatient = new PatientVM
                        {
                            Name = model.PatientName,
                            BirthDate = model.PatientBirthDate,
                            Address = model.PatientAddress,
                            PhoneNumber = model.PatientPhoneNumber,
                            SSN = model.PatientSSN
                        };
                        await patientService.Create(newPatient);

                        // Retrieve the newly created patient ID

                        var createdPatientId = await patientService.GetPatientIdByNameAsync(model.PatientName);
                        if (createdPatientId.HasValue)
                        {
                            model.PatientId = createdPatientId.Value;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Failed to retrieve the newly created patient ID.");
                            return View(model);
                        }
                    }

                    await appointmentService.Create(model);

                    return RedirectToAction("Index");
                }

                await PopulateViewData();
                return View(model);

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the user.");
                await PopulateViewData();
                return View(model);

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
                    await PopulateViewData();

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
            var patients = await patientService.GetAll();
            ViewBag.Patients = new SelectList(patients, "Id", "Name");
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots(int doctorId, DateTime date)
        {
            try
            {
                var slots = await appointmentService.GetAvailableSlots(doctorId, date);
                return Json(slots);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
