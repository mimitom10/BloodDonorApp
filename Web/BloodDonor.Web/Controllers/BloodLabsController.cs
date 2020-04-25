namespace BloodDonor.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonor.Services.Data.BloodLabsServices;
    using BloodDonor.Web.ViewModels.BloodLabs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BloodLabsController : Controller
    {
        private readonly IBloodLabsService bloodLabsService;

        public BloodLabsController(IBloodLabsService bloodLabsService)
        {
            this.bloodLabsService = bloodLabsService;
        }

        public IActionResult ById(string id)
        {
            var viewModel = this.bloodLabsService.GetBloodLabById<BloodLabViewModel>(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
