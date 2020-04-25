namespace BloodDonor.Web.ViewModels.Locations
{
    using System.ComponentModel.DataAnnotations;

    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

    public class LocationViewModel : IMapTo<Location>
    {
        [Required]
        public string TownName { get; set; }
    }
}
