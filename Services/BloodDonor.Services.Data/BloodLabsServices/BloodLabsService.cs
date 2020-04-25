using BloodDonor.Data.Common.Repositories;
using BloodDonor.Data.Models;
using BloodDonor.Services.Mapping;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodDonor.Services.Data.BloodLabsServices
{
    public class BloodLabsService : IBloodLabsService
    {
        private readonly IDeletableEntityRepository<BloodLab> bloodLabsRepository;

        public BloodLabsService(IDeletableEntityRepository<BloodLab> bloodLabsRepository)
        {
            this.bloodLabsRepository = bloodLabsRepository;
        }

        public T GetBloodLabById<T>(string id)
        {
            var bloodLab = this.bloodLabsRepository.All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return bloodLab;
        }

        public IEnumerable<T> GetLabsByTownName<T>(string town)
        {
            IQueryable<BloodLab> query =
               this.bloodLabsRepository.All()
               .Where(x => x.Location.TownName.ToLower() == town.ToLower());

            return query.To<T>().ToList();
        }
    }
}
