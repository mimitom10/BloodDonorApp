using BloodDonor.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Location : BaseDeletableModel<string>
    {
        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Donors = new HashSet<Donor>();
        }


        public string TownName { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }
    }

}
