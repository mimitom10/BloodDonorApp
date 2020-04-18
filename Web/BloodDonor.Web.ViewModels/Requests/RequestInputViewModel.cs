using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Web.ViewModels.Requests
{
    public class RequestInputViewModel
    {
        [Required]
        public string PatientId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string MedicalCondition { get; set; }

        [MaxLength(300)]
        public string PeronalMessage { get; set; }

    }
}
