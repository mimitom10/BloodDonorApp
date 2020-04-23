﻿namespace BloodDonor.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

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

        public bool IsRegisteredPatient(string userId)
        {
            var patient = this.patientsRepository.All()
                .Where(x => x.UserId == userId)
                .ToList();
            if(patient.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T GetPatientByUserId<T>(string userId)
        {
            var patient = this.patientsRepository.All()
               .Where(x => x.User.Id == userId)
               .To<T>().FirstOrDefault();

            return patient;
        }

        public async Task EditAsync(string fullName, string phoneNumber, string bloodType, string locationId, string userId)
        {
            var patientToEdit = this.patientsRepository.All()
               .Where(x => x.User.Id == userId)
               .ToList().FirstOrDefault();


            //patientToEdit.FullName = fullName;
            //patientToEdit.PhoneNumber = phoneNumber;
            //patientToEdit.BloodType = bloodType;
            //patientToEdit.LocationId = locationId;
            //// patientToEdit.UserId = userId;



            var editedPatient = new Patient
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                BloodType = bloodType,
                LocationId = locationId,
                UserId = userId,
            };

            
        }

        public async Task DeleteAsync(string userId)
        {
            var patientToDelete = this.patientsRepository.All()
                 .Where(x => x.User.Id == userId)
               .ToList().FirstOrDefault();

             this.patientsRepository.Delete(patientToDelete);

            await this.patientsRepository.SaveChangesAsync();
        }
    }
}
