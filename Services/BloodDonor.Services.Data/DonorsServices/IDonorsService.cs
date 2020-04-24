namespace BloodDonor.Services.Data.DonorsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDonorsService
    {
        bool IsRegisteredDonor(string userId);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetDonorsWithOpenDonations<T>();

        Task RegisterAsync(string fullName, string phoneNumber, string bloodType, string locationId, string userId);

        T GetDonorByUserId<T>(string userId);
    }
}
