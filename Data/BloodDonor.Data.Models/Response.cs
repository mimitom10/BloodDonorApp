using BloodDonor.Data.Common.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Response : BaseDeletableModel<int>
    {
      //  public string BloodType { get; set; }

        public int Quantity { get; set; }

        // public string Location { get; set; }

        public string Details { get; set; }

        [Required]
        public string DonorId { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
