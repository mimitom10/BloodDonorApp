namespace BloodDonor.Services.Data.ResponsesServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using BloodDonor.Data.Common.Repositories;
    using BloodDonor.Data.Models;

    public class ResponsesService : IResponsesService
    {
        private readonly IDeletableEntityRepository<Response> responsesRepository;

        public ResponsesService(IDeletableEntityRepository<Response> responsesRepository)
        {
            this.responsesRepository = responsesRepository;
        }

        public async Task AddAsync(string details, bool isAnonymous, string donorId, string requestId)
        {
            var response = new Response
            {
                Details = details,
                IsAnonymous = isAnonymous,
                DonorId = donorId,
                RequestId = requestId,
            };
            await this.responsesRepository.AddAsync(response);
            await this.responsesRepository.SaveChangesAsync();
        }
    }
}
