using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Services.Data
{
    public interface IPatientsService
    {
        Task<string> RegisterAsync(string fullName, string phoneNumber, string bloodType, string locationId, string userId);
    }
}
