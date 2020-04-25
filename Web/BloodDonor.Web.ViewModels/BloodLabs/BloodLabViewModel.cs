namespace BloodDonor.Web.ViewModels.BloodLabs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

    public class BloodLabViewModel : IMapFrom<BloodLab>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string LocationId { get; set; }

        public string LocationTownName { get; set; }
    }
}
