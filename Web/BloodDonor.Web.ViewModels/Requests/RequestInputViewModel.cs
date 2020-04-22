namespace BloodDonor.Web.ViewModels.Requests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class RequestInputViewModel
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
