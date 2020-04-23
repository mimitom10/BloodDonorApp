namespace BloodDonor.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;
    using BloodDonor.Services.Data;
    using BloodDonor.Web.ViewModels.Donors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using System.Security.Claims;

    public class DonorsController : Controller
    {
        private readonly IDonorsService donorsService;
        private readonly IDeletableEntityRepository<Location> locationsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public DonorsController(IDonorsService donorsService,
           IDeletableEntityRepository<Location> locationsRepository,
           UserManager<ApplicationUser> userManage)
        {
            this.donorsService = donorsService;
            this.locationsRepository = locationsRepository;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Profile()
        {
            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.donorsService.GetDonorByUserId<DonorRegisterInputModel>(userId);
            if (!this.donorsService.IsRegisteredDonor(userId))
            {
                return this.Redirect("/Donors/Register");
            }
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Register()
        {
            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (this.donorsService.IsRegisteredDonor(userId))
            {
                return this.Redirect("/Requests/List");
            }
            return this.View();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Register(DonorRegisterInputModel input)
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

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // var userId = this.userManager.GetUserId(this.User);
            //this.User.Claims.FirstOrDefault().ToString();
            var locationId = location.Id;
            var donorId = await this.donorsService.RegisterAsync(input.FullName, input.PhoneNumber, input.BloodType, locationId, userId);
            return this.Redirect("/Requests/List");
        }

        [Authorize(Roles = "Administrator")]

        public IActionResult List()
        {
            var viewModel = new DonorListViewModel
            {
                Donors = this.donorsService.GetAll<DonorRegisterInputModel>(),
            };
            return this.View(viewModel);
        }

    }
}
