using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonor.Web.ViewModels.Requests
{
    public class RequestListViewModel
    {
        public IEnumerable<RequestViewModel> Requests { get; set; }
    }
}
