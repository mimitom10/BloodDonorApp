using BloodDonor.Data.Models;
using BloodDonor.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonor.Web.ViewModels.Requests
{
    public class RequestViewModel : IMapFrom<Request>
    {
        public string PatientFullName { get; set; }

        public string PatientBloodType { get; set; }

        public string PatientLocationTownName { get; set; }

        public string Url => $"/{this.PatientFullName.Replace(' ', '-')}";

        // public int Quantity { get; set; }

        // public string MedicalCondition { get; set; }

        // public string PeronalMessage { get; set; }
    }
}
