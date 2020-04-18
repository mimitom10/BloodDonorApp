namespace BloodDonor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BloodDonor.Data.Common.Models;

    public class Notification : BaseDeletableModel<string>
    {
        public Notification()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Messqaage { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
