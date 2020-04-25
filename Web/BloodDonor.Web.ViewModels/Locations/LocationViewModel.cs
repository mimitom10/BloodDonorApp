namespace BloodDonor.Web.ViewModels.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

    public class LocationViewModel : IMapFrom<Location>, IMapTo<Location>
    {
        public string TownName { get; set; }
    }
}
