namespace BloodDonor.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonor.Data;
    using BloodDonor.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext context;

        public PatientsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.Patients.Include(p => p.Location).Include(p => p.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var patient = await this.context.Patients
                .Include(p => p.Location)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return this.NotFound();
            }

            return this.View(patient);
        }

        public IActionResult Create()
        {
            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id");
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id");
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,PhoneNumber,BloodType,LocationId,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Patient patient)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(patient);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", patient.LocationId);
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id", patient.UserId);
            return this.View(patient);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var patient = await this.context.Patients.FindAsync(id);
            if (patient == null)
            {
                return this.NotFound();
            }

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", patient.LocationId);
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id", patient.UserId);
            return this.View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,PhoneNumber,BloodType,LocationId,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Patient patient)
        {
            if (id != patient.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(patient);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PatientExists(patient.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", patient.LocationId);
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id", patient.UserId);
            return this.View(patient);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var patient = await this.context.Patients
                .Include(p => p.Location)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return this.NotFound();
            }

            return this.View(patient);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patient = await this.context.Patients.FindAsync(id);
            this.context.Patients.Remove(patient);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool PatientExists(string id)
        {
            return this.context.Patients.Any(e => e.Id == id);
        }
    }
}
