using BloodDonor.Services.Data.RequestsServices;
using BloodDonor.Web.ViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonor.Web.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestsService requestsService;
        public RequestsController(IRequestsService requestsService)
        {
            this.requestsService = requestsService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Add(RequestInputViewModel input)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
           

           // var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          //  var patientId = 

          //  var requestId = await this.requestsService.AddAsync(input.Quantity, input.MedicalCondition, input.PeronalMessage, patientId);
            return this.Redirect("/");
        }
    }
}
