using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonor.Services.Data.LocationsServices
{
    public interface ILocationsService
    {
        IEnumerable<T> GetLabsByTownName<T>(string town);
    }
}
