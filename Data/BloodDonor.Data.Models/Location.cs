using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonor.Data.Models
{
    public class Location
    {
        public Location()
        {
            this.Users = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }
        public string TownName { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
