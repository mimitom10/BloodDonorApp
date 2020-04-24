namespace BloodDonor.Web.ViewModels.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

    public class RequestViewModel : IMapFrom<Request>
    {
        public string Id { get; set; }

        public string PatientUserId { get; set; }

        public ApplicationUser PatientUser { get; set; }

        public string PatientFullName { get; set; }

        public string PatientBloodType { get; set; }

        public string PatientLocationTownName { get; set; }

        public int Quantity { get; set; }

        public string MedicalCondition { get; set; }

        public string PersonalMessage { get; set; }
    }
}
