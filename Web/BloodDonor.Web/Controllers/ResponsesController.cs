using BloodDonor.Web.ViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonor.Web.Controllers
{
    public class ResponsesController : Controller
    {
        public ResponsesController()
        {

        }


        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]

        public async Task<IActionResult> Add(ResponseInputViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            //var userId = this.userManager.GetUserId(this.User);
            //var patient = this.patientsRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            //var patientId = patient.Id;

            //var requestId = await this.requestsService.AddAsync(patientId, input.Quantity, input.MedicalCondition, input.PersonalMessage);

            return this.Redirect("/Requests/List");
        }
    }
}
