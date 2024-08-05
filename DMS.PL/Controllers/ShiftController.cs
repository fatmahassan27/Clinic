using DMS.BLL.Interfaces;
using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DMS.PL.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftService shiftService;

        public ShiftController(IShiftService shiftService) 
        {
            this.shiftService = shiftService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shifts = await shiftService.GetAll();
            return View(shifts);
        }
        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShiftVM shift)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await shiftService.Create(shift);
                    return RedirectToAction(nameof(Index));
                }
                return View(shift);

            }catch(Exception ex)
            {

                ModelState.AddModelError("", "An error occurred while creating the user.");
                return View();
            }
        }
    }
}
