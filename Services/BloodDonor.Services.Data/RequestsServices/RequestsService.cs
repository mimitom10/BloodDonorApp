using BloodDonor.Data.Common.Repositories;
using BloodDonor.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Services.Data.RequestsServices
{
    public class RequestsService : IRequestsService
    {
        private readonly IDeletableEntityRepository<Request> requestsRepository;
        public RequestsService(IDeletableEntityRepository<Request> requestsRepository)
        {
            this.requestsRepository = requestsRepository;
        }
        public async Task<string> AddAsync(int quantity, string medicalCondition, string personalMessage, string patientId)
        {
            
            var request = new Request
            {
                Quantity = quantity,
                MedicalCondition = medicalCondition,
                PeronalMessage = personalMessage,
                PatientId = patientId
            };
            await this.requestsRepository.AddAsync(request);
            await this.requestsRepository.SaveChangesAsync();
            return request.Id;
        }
    }
}
