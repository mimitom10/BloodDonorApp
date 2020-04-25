using BloodDonor.Data.Common.Repositories;
using BloodDonor.Data.Models;
using BloodDonor.Services.Mapping;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodDonor.Services.Data.LocationsServices
{
    public class LocationsService : ILocationsService
    {
        private readonly IDeletableEntityRepository<Location> locationsRepository;

        public LocationsService(IDeletableEntityRepository<Location> locationsRepository)
        {
            this.locationsRepository = locationsRepository;
        }

        //public IEnumerable<T> GetLabsByTownName<T>(string town)
        //{
        //    IQueryable<Location> query =
        //        this.locationsRepository.All()
        //        .Where(x => x.TownName.ToLower() == town.ToLower());

        //    return query.To<T>().ToList();
        //}
    }
}
