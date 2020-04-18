using BloodDonor.Data.Common.Repositories;
using BloodDonor.Data.Models;
using BloodDonor.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> AddAsync(string patientId, int quantity, string medicalCondition, string personalMessage)
        {

            var request = new Request
            {
                PatientId = patientId,
                Quantity = quantity,
                MedicalCondition = medicalCondition,
                PeronalMessage = personalMessage,
            };
            await this.requestsRepository.AddAsync(request);
            await this.requestsRepository.SaveChangesAsync();
            return request.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Request> query =
                 this.requestsRepository.All().OrderBy(x => x.Patient.FullName);


            return query.To<T>().ToList();
        }
    }
}
