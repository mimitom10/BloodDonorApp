namespace BloodDonor.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDonorsService
    {
        IEnumerable<T> GetAll<T>();
        Task<string> RegisterAsync(string fullName, string phoneNumber, string bloodType, string locationId, string userId);

        // string Register(string fullName, string phoneNumber, string bloodType, string userId);
    }
}
