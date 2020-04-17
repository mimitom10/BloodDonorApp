using BloodDonor.Data.Models;
using BloodDonor.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Web.ViewModels.Patients
{
    public class PatientRegisterInputModel : IMapFrom<Patient>
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string BloodType { get; set; }

        public string LocationTownName { get; set; }



    }
}
