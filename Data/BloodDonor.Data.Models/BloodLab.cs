namespace BloodDonor.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BloodDonor.Data.Common.Models;

    public class BloodLab : BaseDeletableModel<string>
    {
        public BloodLab()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
