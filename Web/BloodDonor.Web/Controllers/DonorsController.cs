namespace BloodDonor.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonor.Data.Models;
    using BloodDonor.Services.Data;
    using BloodDonor.Web.ViewModels.Donors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

   // using System.Security.Claims;
    public class DonorsController : Controller
    {
        private readonly IDonorsService donorsService;
        private readonly UserManager<ApplicationUser> userManager;

        public DonorsController(IDonorsService donorsService,
            UserManager<ApplicationUser> userManage)
        {
            this.donorsService = donorsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]

        public IActionResult Register(DonorRegisterInputModel input)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.Claims.FirstOrDefault().ToString();
                //HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var donorId = this.donorsService.Register(input.FullName, input.PhoneNumber, input.BloodType, userId);
            return this.Redirect("/");
        }



        //public async Task<IActionResult> Register(DonorRegisterInputModel input)
        //{

        //    if (!this.ModelState.IsValid)
        //    { 
        //        return this.View(input);
        //    }

        //    var user =  await this.userManager.GetUserAsync(this.User);
        //    var donorId = await this.donorsService.RegisterAsync(input.FullName, input.PhoneNumber, input.BloodType, user.Id);
        //    return this.Redirect("/");
        //}

       
    }
}
