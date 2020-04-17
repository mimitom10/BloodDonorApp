namespace BloodDonor.Web.ViewModels.Donors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;


    public class DonorRegisterInputModel : IMapFrom<Donor>
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
       
        [Required]
        public string PhoneNumber { get; set; }

        public string BloodType { get; set; }

        public string LocationTownName { get; set; }

        // public bool HasCovidAntiBodies { get; set; }

    }
}
