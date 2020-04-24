namespace BloodDonor.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;
    using BloodDonor.Services.Data.RequestsServices;
    using BloodDonor.Web.ViewModels.Requests;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RequestsController : Controller
    {
        private readonly IRequestsService requestsService;
        private readonly IDeletableEntityRepository<Patient> patientsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public RequestsController(
            IRequestsService requestsService,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<Patient> patientsRepository)
        {
            this.requestsService = requestsService;
            this.userManager = userManager;
            this.patientsRepository = patientsRepository;
        }

        [Authorize]

        public IActionResult List()
        {
            var viewModel = new RequestListViewModel
            {
                Requests = this.requestsService.GetAll<RequestViewModel>(),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult ListById(string id)
        {
            var currentUserId = this.userManager.GetUserId(this.User);

            if (currentUserId == id)
            {
                var viewModel = new RequestListViewModel
                {
                    Requests = this.requestsService.GetAllById<RequestViewModel>(id),
                };
                return this.View(viewModel);
            }
            else
            {
                return this.Redirect("/Requests/List");
            }
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

            var userId = this.userManager.GetUserId(this.User);
            var patient = this.patientsRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            var patientId = patient.Id;
            if (this.requestsService.HasReachedMaxRequests(userId))
            {
                return this.Redirect("/Requests/List");
            }

            var requestId = await this.requestsService.AddAsync(patientId, input.Quantity, input.MedicalCondition, input.PersonalMessage);

            return this.Redirect("/Requests/List");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var currentUserId = this.userManager.GetUserId(this.User);
            var patient = this.patientsRepository.All()
                .Where(x => x.Requests.FirstOrDefault(r => r.Id == id).Id == id)
                .FirstOrDefault();
            var requestUserId = this.requestsService.GetRequestById<RequestViewModel>(id);
            if (currentUserId == patient.UserId)
            {
                return this.View();
            }
            else
            {
                return this.Redirect("/Requests/List");
            }
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
           await this.requestsService.DeleteAsync(id);
           return this.Redirect("/Requests/ListById");
        }

        public IActionResult ById(string id)
        {
            var viewModel = this.requestsService.GetRequestById<RequestViewModel>(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

    }
}
