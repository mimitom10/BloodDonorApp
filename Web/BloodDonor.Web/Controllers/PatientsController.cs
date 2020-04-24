namespace BloodDonor.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using BloodDonor.Data;
    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;
    using BloodDonor.Services.Data;
    using BloodDonor.Web.ViewModels.Patients;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class PatientsController : Controller
    {
        private readonly IPatientsService patientsService;
        private readonly IDeletableEntityRepository<Location> locationsRepository;
        private readonly IDeletableEntityRepository<Patient> patientsRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public PatientsController(IPatientsService patientsService,
            IDeletableEntityRepository<Location> locationsRepository,
            IDeletableEntityRepository<Patient> patientsRepository,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db)
        {
            this.patientsService = patientsService;
            this.locationsRepository = locationsRepository;
            this.patientsRepository = patientsRepository;
            this.userManager = userManager;
            this.db = db;
        }

        [Authorize]
        public IActionResult Profile()
        {
            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.patientsService.GetPatientByUserId<PatientRegisterInputModel>(userId);
            if (!this.patientsService.IsRegisteredPatient(userId))
            {
                return this.Redirect("/Patients/Register");
            }

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Register()
        {
            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (this.patientsService.IsRegisteredPatient(userId))
            {
                return this.Redirect("/Requests/Add");
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Register(PatientRegisterInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var location = new Location
            {
                TownName = input.LocationTownName,
            };
            await this.locationsRepository.AddAsync(location);
            await this.locationsRepository.SaveChangesAsync();

            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var locationId = location.Id;
            var patientId = await this.patientsService.RegisterAsync(input.FullName, input.PhoneNumber, input.BloodType, locationId, userId);
            return this.Redirect("/Requests/Add");
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = patientsService.GetPatientByUserId<PatientRegisterInputModel>(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,PhoneNumber,BloodType,LocationId,UserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(patient);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!patientsService.IsRegisteredPatient(patient.UserId))
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
            ViewData["LocationId"] = new SelectList(db.Locations, "Id", "Id", patient.LocationId);
            ViewData["UserId"] = new SelectList(db.Users, "Id", "Id", patient.UserId);
            return View(patient);
        }
    }
}
