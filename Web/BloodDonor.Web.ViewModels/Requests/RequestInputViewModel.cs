namespace BloodDonor.Web.ViewModels.Requests
{
    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class RequestInputViewModel : IMapFrom<Request>
    {
        [Required]
        [Range(1, 5)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string MedicalCondition { get; set; }

        [MaxLength(300)]
        public string PersonalMessage { get; set; }
    }
}
