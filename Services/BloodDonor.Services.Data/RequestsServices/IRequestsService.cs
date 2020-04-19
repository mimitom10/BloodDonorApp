namespace BloodDonor.Services.Data.RequestsServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRequestsService
    {
        IEnumerable<T> GetAll<T>();

        Task<string> AddAsync(string patientId, int quantity, string medicalCondition, string personalMessage);

        T SelectRequest<T>(string patientFullName);
    }
}
