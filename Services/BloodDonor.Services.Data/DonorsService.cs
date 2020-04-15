namespace BloodDonor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;

    public class DonorsService : IDonorsService
    {
        private readonly IDeletableEntityRepository<Donor> donorsRepository;

        public DonorsService(IDeletableEntityRepository<Donor> donorsRepository)
        {
            this.donorsRepository = donorsRepository;
        }

        public async Task RegisterAsync(string fullName, string phoneNumber, string bloodType)
        {
            var donor = new Donor
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                BloodType = bloodType,
            };
            await this.donorsRepository.AddAsync(donor);
            await this.donorsRepository.SaveChangesAsync();

        }
    }
}
