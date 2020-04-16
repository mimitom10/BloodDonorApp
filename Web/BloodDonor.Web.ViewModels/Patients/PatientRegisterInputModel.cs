using BloodDonor.Data.Models;
using BloodDonor.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Web.ViewModels.Patients
{
    public class PatientRegisterInputModel : IMapTo<Patient>
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        public string BloodType { get; set; }
    }
}
