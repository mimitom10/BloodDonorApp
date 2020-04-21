using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonor.Web.ViewModels.Donors
{
    public class DonorListViewModel
    {
        public IEnumerable<DonorRegisterInputModel> Donors { get; set; }
    }
}
