namespace BloodDonor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BloodDonor.Data.Common.Models;

    public class Response : BaseDeletableModel<string>
    {
        public Response()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Details { get; set; }

        [Required]

        public bool IsAnonymous { get; set; }

        public bool IsConfirmed { get; set; }

        [Required]
        public string DonorId { get; set; }

        public virtual Donor Donor { get; set; }

        [Required]
        public string RequestId { get; set; }

        public virtual Request Request { get; set; }
    }
}
