using BloodDonor.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Response : BaseDeletableModel<int>
    {
        public string BloodType { get; set; }

        public int Quantity { get; set; }

        // public string Location { get; set; }

        public string Details { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
