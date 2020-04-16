namespace BloodDonor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BloodDonor.Data.Common.Models;

    public class Request : BaseDeletableModel<int>
    {
        public string BloodType { get; set; }

        public int Quantity { get; set; }

        // public string Location { get; set; }

        public string Details { get; set; }

        [Required]
        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
