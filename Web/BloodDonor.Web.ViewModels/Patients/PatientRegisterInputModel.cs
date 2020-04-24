namespace BloodDonor.Web.ViewModels.Patients
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

    public class PatientRegisterInputModel : IMapFrom<Patient>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string BloodType { get; set; }

        public string LocationId { get; set; }

        public string LocationTownName { get; set; }
    }
}
