using BloodDonor.Data.Common.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Donor : BaseDeletableModel<string>
    {
        public Donor()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Responses = new HashSet<Response>();
        }

        [Requireed]
        [MaxLength(50)]
        public string FullName { get; set; }

      //  [Required]
      //  public string Town { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        public string BloodType { get; set; }

        // public bool HasCovidAntiBodies { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        [Required]
        public string UserId { get; set; }


        public virtual ICollection<Response> Responses { get; set; }

    }
}
