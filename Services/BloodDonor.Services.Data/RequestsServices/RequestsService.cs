namespace BloodDonor.Services.Data.RequestsServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;
    using BloodDonor.Services.Mapping;

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
                PersonalMessage = personalMessage,
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

        public IEnumerable<T> GetAllById<T>(string id)
        {
            IQueryable<Request> query =
                 this.requestsRepository.All()
                 .Where(x => x.Patient.UserId == id)
                 .OrderBy(x => x.Patient.FullName);

            return query.To<T>().ToList();
        }

        public T GetRequestById<T>(string id)
        {
            var request = this.requestsRepository.All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return request;
        }

        public bool HasReachedMaxRequests(string userId)
        {
            var requests = this.requestsRepository.All()
                .Where(x => x.Patient.UserId == userId)
                .ToList();
            if(requests.Count >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
