using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Services.Data.ResponsesServices
{
    public interface IResponsesService
    {
        Task<string> AddAsync(string details, bool isAnonymous, string donorId, string requestId);
    }
}
