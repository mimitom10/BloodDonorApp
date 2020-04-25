namespace BloodDonor.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonor.Data;
    using BloodDonor.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class BloodLabsController : Controller
    {
        private readonly ApplicationDbContext context;

        public BloodLabsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.BloodLabs.Include(b => b.Location);
            return this.View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var bloodLab = await this.context.BloodLabs
                .Include(b => b.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodLab == null)
            {
                return this.NotFound();
            }

            return this.View(bloodLab);
        }

        public IActionResult Create()
        {
            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id");
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,PhoneNumber,LocationId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] BloodLab bloodLab)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(bloodLab);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", bloodLab.LocationId);
            return this.View(bloodLab);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var bloodLab = await this.context.BloodLabs.FindAsync(id);
            if (bloodLab == null)
            {
                return this.NotFound();
            }

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", bloodLab.LocationId);
            return this.View(bloodLab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Address,PhoneNumber,LocationId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] BloodLab bloodLab)
        {
            if (id != bloodLab.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(bloodLab);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BloodLabExists(bloodLab.Id))
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

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", bloodLab.LocationId);
            return this.View(bloodLab);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var bloodLab = await this.context.BloodLabs
                .Include(b => b.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodLab == null)
            {
                return this.NotFound();
            }

            return this.View(bloodLab);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bloodLab = await this.context.BloodLabs.FindAsync(id);
            this.context.BloodLabs.Remove(bloodLab);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BloodLabExists(string id)
        {
            return this.context.BloodLabs.Any(e => e.Id == id);
        }
    }
}
