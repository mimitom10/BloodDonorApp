using BloodDonor.Services.Data.BloodLabsServices;
using BloodDonor.Web.ViewModels.BloodLabs;
using BloodDonor.Web.ViewModels.Locations;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonor.Web.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IBloodLabsService bloodLabsService;

        public LocationsController(IBloodLabsService bloodLabsService)
        {
            this.bloodLabsService = bloodLabsService;
        }

        public IActionResult LabAddresses()
        {
            //var viewModel = new LocationViewModel
            //{
            //    TownName = town
            //};
            return this.View();
        }

       // [HttpPost]
        //public IActionResult LabAddresses(LocationViewModel input)
        //{
        //    string town = input.TownName;
        //    var viewModel = new BloodLabListViewModel
        //    {
        //        BloodLabs = this.bloodLabsService.GetLabsByTownName<BloodLabViewModel>(town),
        //    };

        //    return Redirect("/Locations/LabAddressesList");
        //}


        public IActionResult LabAddressesList(string town)
        {
            var viewModel = new BloodLabListViewModel
            {
                BloodLabs = this.bloodLabsService.GetLabsByTownName<BloodLabViewModel>(town),
            };

            return this.View(viewModel);
        }
    }
}
