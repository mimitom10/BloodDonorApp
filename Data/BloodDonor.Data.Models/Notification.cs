using BloodDonor.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Notification : BaseDeletableModel<int>
    {
        public string Messqaage { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
