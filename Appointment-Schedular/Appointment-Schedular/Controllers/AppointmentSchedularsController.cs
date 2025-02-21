using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Appointment_Schedular.Models;

namespace Appointment_Schedular.Controllers
{
    public class AppointmentSchedularsController : Controller
    {
        private readonly AppointmentSchedularContext _context;

        public AppointmentSchedularsController(AppointmentSchedularContext context)
        {
            _context = context;
        }

        // GET: AppointmentSchedulars
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppointmentSchedulars.ToListAsync());
        }

        // GET: AppointmentSchedulars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentSchedular = await _context.AppointmentSchedulars
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentSchedular == null)
            {
                return NotFound();
            }

            return View(appointmentSchedular);
        }

        // GET: AppointmentSchedulars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppointmentSchedulars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,Name,Phone,Address,Date,TimeSlot,RemarkOfAppointment,NoOfHours,FeesCharged")] AppointmentSchedular appointmentSchedular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentSchedular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentSchedular);
        }

        // GET: AppointmentSchedulars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentSchedular = await _context.AppointmentSchedulars.FindAsync(id);
            if (appointmentSchedular == null)
            {
                return NotFound();
            }
            return View(appointmentSchedular);
        }

        // POST: AppointmentSchedulars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,Name,Phone,Address,Date,TimeSlot,RemarkOfAppointment,NoOfHours,FeesCharged")] AppointmentSchedular appointmentSchedular)
        {
            if (id != appointmentSchedular.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentSchedular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentSchedularExists(appointmentSchedular.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentSchedular);
        }

        // GET: AppointmentSchedulars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentSchedular = await _context.AppointmentSchedulars
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointmentSchedular == null)
            {
                return NotFound();
            }

            return View(appointmentSchedular);
        }

        // POST: AppointmentSchedulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentSchedular = await _context.AppointmentSchedulars.FindAsync(id);
            if (appointmentSchedular != null)
            {
                _context.AppointmentSchedulars.Remove(appointmentSchedular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentSchedularExists(int id)
        {
            return _context.AppointmentSchedulars.Any(e => e.AppointmentId == id);
        }
    }
}
