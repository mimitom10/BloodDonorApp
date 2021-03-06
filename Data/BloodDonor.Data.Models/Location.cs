﻿namespace BloodDonor.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BloodDonor.Data.Common.Models;

    public class Location : BaseDeletableModel<string>
    {
        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Donors = new HashSet<Donor>();
            this.Patients = new HashSet<Patient>();
            this.BloodLabs = new HashSet<BloodLab>();
        }

        public string TownName { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<BloodLab> BloodLabs { get; set; }
    }
}
