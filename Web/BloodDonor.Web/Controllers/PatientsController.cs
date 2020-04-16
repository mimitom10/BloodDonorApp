using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonor.Web.Controllers
{
    public class PatientsController : Controller
    {
        public PatientsController()
        {

        }

        [Authorize]
        public IActionResult Register()
        {
            return this.View();
        }
    }
}
