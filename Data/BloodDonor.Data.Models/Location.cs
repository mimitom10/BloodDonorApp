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
            this.Patients = new HashSet<Patient>();
        }


        public string TownName { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }


    }

}
