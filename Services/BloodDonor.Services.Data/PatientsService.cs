namespace BloodDonor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;

    public class PatientsService : IPatientsService
    {
        private readonly IDeletableEntityRepository<Patient> patientsRepository;

        public PatientsService(IDeletableEntityRepository<Patient> patientsRepository)
        {
            this.patientsRepository = patientsRepository;
        }
        public async Task<string> RegisterAsync(string fullName, string phoneNumber, string bloodType, string locationId, string userId)
        {
            var patient = new Patient
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                BloodType = bloodType,
                LocationId = locationId,
                UserId = userId,
            };
            await this.patientsRepository.AddAsync(patient);
            await this.patientsRepository.SaveChangesAsync();
            return patient.Id;
        }
    }
}
