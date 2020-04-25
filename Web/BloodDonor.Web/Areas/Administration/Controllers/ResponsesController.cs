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
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ResponsesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.Responses.Include(r => r.Donor).Include(r => r.Request);
            return this.View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var response = await this.context.Responses
                .Include(r => r.Donor)
                .Include(r => r.Request)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (response == null)
            {
                return this.NotFound();
            }

            return this.View(response);
        }

        public IActionResult Create()
        {
            this.ViewData["DonorId"] = new SelectList(this.context.Donors, "Id", "Id");
            this.ViewData["RequestId"] = new SelectList(this.context.Requests, "Id", "Id");
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Details,IsAnonymous,IsConfirmed,DonorId,RequestId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Response response)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(response);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["DonorId"] = new SelectList(this.context.Donors, "Id", "Id", response.DonorId);
            this.ViewData["RequestId"] = new SelectList(this.context.Requests, "Id", "Id", response.RequestId);
            return this.View(response);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var response = await this.context.Responses.FindAsync(id);
            if (response == null)
            {
                return this.NotFound();
            }

            this.ViewData["DonorId"] = new SelectList(this.context.Donors, "Id", "Id", response.DonorId);
            this.ViewData["RequestId"] = new SelectList(this.context.Requests, "Id", "Id", response.RequestId);
            return this.View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Details,IsAnonymous,IsConfirmed,DonorId,RequestId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Response response)
        {
            if (id != response.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(response);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ResponseExists(response.Id))
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

            this.ViewData["DonorId"] = new SelectList(this.context.Donors, "Id", "Id", response.DonorId);
            this.ViewData["RequestId"] = new SelectList(this.context.Requests, "Id", "Id", response.RequestId);
            return this.View(response);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var response = await this.context.Responses
                .Include(r => r.Donor)
                .Include(r => r.Request)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (response == null)
            {
                return this.NotFound();
            }

            return this.View(response);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var response = await this.context.Responses.FindAsync(id);
            this.context.Responses.Remove(response);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ResponseExists(string id)
        {
            return this.context.Responses.Any(e => e.Id == id);
        }
    }
}
