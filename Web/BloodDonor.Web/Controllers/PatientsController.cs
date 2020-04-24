namespace BloodDonor.Web.Controllers
{
    using System.Collections.Generic;
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

    public class PatientsController : Controller
    {
        private readonly IPatientsService patientsService;
        private readonly IDeletableEntityRepository<Location> locationsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public PatientsController(
            IPatientsService patientsService,
            IDeletableEntityRepository<Location> locationsRepository,
            IDeletableEntityRepository<Patient> patientsRepository,
            UserManager<ApplicationUser> userManager
           )
        {
            this.patientsService = patientsService;
            this.locationsRepository = locationsRepository;
            this.userManager = userManager;
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
    }
}
