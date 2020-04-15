using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Location
    {
        public Location()
        {
            this.Donors = new HashSet<Donor>();
        }

        public int Id { get; set; }

        public string TownName { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }
    }
}
