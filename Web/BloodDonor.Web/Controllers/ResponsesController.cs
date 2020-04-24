using BloodDonor.Data.Common.Repositories;
using BloodDonor.Data.Models;
using BloodDonor.Services.Data.ResponsesServices;
using BloodDonor.Web.ViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonor.Web.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly IResponsesService responsesService;
        private readonly IDeletableEntityRepository<Donor> donorsRepository;
        private readonly UserManager<ApplicationUser> userManager;


        public ResponsesController(
            IResponsesService responsesService,
            IDeletableEntityRepository<Donor> donorsRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            this.responsesService = responsesService;
            this.donorsRepository = donorsRepository;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add(string id)
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]

        public async Task<IActionResult> Add(ResponseInputViewModel input, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            var donor = this.donorsRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            var donorId = donor.Id;

            await this.responsesService.AddAsync(input.Details, input.IsAnonymous, donorId, id);

            return this.Redirect("/Requests/List");
        }
    }
}
