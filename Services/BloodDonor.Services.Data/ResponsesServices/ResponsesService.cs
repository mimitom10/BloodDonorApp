using BloodDonor.Data.Common.Repositories;
using BloodDonor.Data.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Services.Data.ResponsesServices
{
    public class ResponsesService : IResponsesService
    {
        private readonly IDeletableEntityRepository<Response> responsesRepository;

        public ResponsesService(IDeletableEntityRepository<Response> responsesRepository)
        {
            this.responsesRepository = responsesRepository;
        }

        public async Task<string> AddAsync(string details, bool isAnonymous, string donorId, string requestId)
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
            return response.Id;
        }
    }
}
