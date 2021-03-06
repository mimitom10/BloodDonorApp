﻿namespace BloodDonor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BloodDonor.Data.Common.Models;

    public class Patient : BaseDeletableModel<string>
    {
        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string BloodType { get; set; }

        [Required]
        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
