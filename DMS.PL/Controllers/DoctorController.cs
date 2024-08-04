﻿using DMS.BLL.Interfaces;
using DMS.BLL.Services;
using DMS.BLL.ViewModels;
using DMS.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace DMS.PL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;
        private readonly IAppointmentService appointmentService;

        public DoctorController(IDoctorService doctorService,IAppointmentService appointmentService)
        {
            this.doctorService = doctorService;
            this.appointmentService = appointmentService;
        }
       

        [HttpGet]
        public async Task<IActionResult> Profile(int doctorId)
        {
            try
            {
                var doctor = await doctorService.GetById(doctorId);
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
        public IActionResult Create()
        {
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
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the user.");

            }
            return View(model);

        }



        public async Task<IActionResult> TodaysAppointments(int doctorId)
        {
            try
            {
                var appointments = await appointmentService.GetTodaysAppointmentsByDoctorId(doctorId);
                return View(appointments);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while retrieving data");

            }
            return NoContent();

        }
        [HttpGet]
        public async Task<IActionResult> AppointmentsByDateRange(int doctorId,DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var appointments = await appointmentService.GetAppointmentsByDateRange(doctorId, dateFrom, dateTo);
                return View(appointments);
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while retrieving data");

            }
            return NotFound();

        }
    }
}
