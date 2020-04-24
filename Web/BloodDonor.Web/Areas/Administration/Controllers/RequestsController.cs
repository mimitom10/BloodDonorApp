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
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext context;

        public RequestsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.Requests.Include(r => r.Patient);
            return this.View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var request = await this.context.Requests
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return this.NotFound();
            }

            return this.View(request);
        }

        public IActionResult Create()
        {
            this.ViewData["PatientId"] = new SelectList(this.context.Patients, "Id", "Id");
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quantity,MedicalCondition,PersonalMessage,PatientId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Request request)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(request);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["PatientId"] = new SelectList(this.context.Patients, "Id", "Id", request.PatientId);
            return this.View(request);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var request = await this.context.Requests.FindAsync(id);
            if (request == null)
            {
                return this.NotFound();
            }

            this.ViewData["PatientId"] = new SelectList(this.context.Patients, "Id", "Id", request.PatientId);
            return this.View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Quantity,MedicalCondition,PersonalMessage,PatientId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Request request)
        {
            if (id != request.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(request);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.RequestExists(request.Id))
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

            this.ViewData["PatientId"] = new SelectList(this.context.Patients, "Id", "Id", request.PatientId);
            return this.View(request);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var request = await this.context.Requests
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return this.NotFound();
            }

            return this.View(request);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var request = await this.context.Requests.FindAsync(id);
            this.context.Requests.Remove(request);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool RequestExists(string id)
        {
            return this.context.Requests.Any(e => e.Id == id);
        }
    }
}
