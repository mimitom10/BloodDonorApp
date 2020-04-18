namespace BloodDonor.Web.ViewModels.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RequestListViewModel
    {
        public IEnumerable<RequestViewModel> Requests { get; set; }
    }
}
