namespace BloodDonor.Web.Controllers
{
    using BloodDonor.Services.Data.BloodLabsServices;
    using BloodDonor.Web.ViewModels.BloodLabs;
    using BloodDonor.Web.ViewModels.Locations;
    using Microsoft.AspNetCore.Mvc;

    public class LocationsController : Controller
    {
        private readonly IBloodLabsService bloodLabsService;

        public LocationsController(IBloodLabsService bloodLabsService)
        {
            this.bloodLabsService = bloodLabsService;
        }

        public IActionResult ByTownName(string id)
        {
            string town = id;

            var viewModelList = new BloodLabListViewModel
            {
                BloodLabs = this.bloodLabsService.GetLabsByTownName<BloodLabViewModel>(town),
            };

            if (viewModelList == null)
            {
                return this.NotFound();
            }

            return this.View(viewModelList);
        }

        public IActionResult LabAddresses()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult LabAddresses(LocationViewModel input)
        {
            string town = input.TownName;

            return this.RedirectToAction(nameof(this.ByTownName), new { id = town });
        }
    }
}
