using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Services.Data.RequestsServices
{
    public interface IRequestsService
    {
        Task<string> AddAsync(int quantity, string medicalCondition, string personalMessage, string patientId);
    }
}
