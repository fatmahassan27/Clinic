using DMS.BLL.Interfaces;
using DMS.BLL.Services;
using DMS.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.PL.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService) 
        {
            this.patientService = patientService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await patientService.Create(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the Patient.");

            }
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> GetPatientNames(string term)
        {
            var patients = await patientService.GetAll();
            var filteredPatients = patients
                .Where(p => p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
                .Select(p => new { p.Id, p.Name })
                .ToList();

            return Json(filteredPatients);
        }

    }
}
