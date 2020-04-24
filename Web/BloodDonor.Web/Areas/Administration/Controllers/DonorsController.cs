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
    public class DonorsController : Controller
    {
        private readonly ApplicationDbContext context;

        public DonorsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.Donors.Include(d => d.Location).Include(d => d.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var donor = await this.context.Donors
                .Include(d => d.Location)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donor == null)
            {
                return this.NotFound();
            }

            return this.View(donor);
        }

        public IActionResult Create()
        {
            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id");
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id");
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,PhoneNumber,BloodType,LocationId,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Donor donor)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(donor);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", donor.LocationId);
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id", donor.UserId);
            return this.View(donor);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var donor = await this.context.Donors.FindAsync(id);
            if (donor == null)
            {
                return this.NotFound();
            }

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", donor.LocationId);
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id", donor.UserId);
            return this.View(donor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,PhoneNumber,BloodType,LocationId,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Donor donor)
        {
            if (id != donor.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(donor);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.DonorExists(donor.Id))
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

            this.ViewData["LocationId"] = new SelectList(this.context.Locations, "Id", "Id", donor.LocationId);
            this.ViewData["UserId"] = new SelectList(this.context.Users, "Id", "Id", donor.UserId);
            return this.View(donor);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var donor = await this.context.Donors
                .Include(d => d.Location)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donor == null)
            {
                return this.NotFound();
            }

            return this.View(donor);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var donor = await this.context.Donors.FindAsync(id);
            this.context.Donors.Remove(donor);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool DonorExists(string id)
        {
            return this.context.Donors.Any(e => e.Id == id);
        }
    }
}
