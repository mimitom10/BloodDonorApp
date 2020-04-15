namespace BloodDonor.Web.Controllers
{
    using BloodDonor.Services.Data;
    using BloodDonor.Web.ViewModels.Donors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DonorsController : Controller
    {
        private readonly IDonorsService donorsService;

        public DonorsController(IDonorsService donorsService)
        {
            this.donorsService = donorsService;
        }

        [Authorize]
        public IActionResult Register()
        {
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
            await this.donorsService.RegisterAsync(input.FullName, input.PhoneNumber, input.BloodType);
            return this.View();
        }
    }
}
