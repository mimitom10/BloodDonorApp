namespace BloodDonor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class DonorsService : IDonorsService
    {
        private readonly IDeletableEntityRepository<Donor> donorsRepository;

        public DonorsService(IDeletableEntityRepository<Donor> donorsRepository)
        {
            this.donorsRepository = donorsRepository;
        }

        //public async Task<string> RegisterAsync(string fullName, string phoneNumber, string bloodType, string userId)
        //{
        //    var donor = new Donor
        //    {
        //        FullName = fullName,
        //        PhoneNumber = phoneNumber,
        //        BloodType = bloodType,
        //        UserId = userId,

        //    };
        //    await this.donorsRepository.AddAsync(donor);
        //    await this.donorsRepository.SaveChangesAsync();
        //    return donor.Id;
        //}

        public string Register(string fullName, string phoneNumber, string bloodType, string userId)
        {
            var donor = new Donor
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                BloodType = bloodType,
                UserId = userId,

            };
            this.donorsRepository.AddAsync(donor);
            this.donorsRepository.SaveChangesAsync();
            return donor.Id;
        }
    }
}
