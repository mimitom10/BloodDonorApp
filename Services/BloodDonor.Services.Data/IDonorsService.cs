namespace BloodDonor.Services.Data
{
    using System.Threading.Tasks;

    public interface IDonorsService
    {
        Task<string> RegisterAsync(string fullName, string phoneNumber, string bloodType, string locationId, string userId);

       // string Register(string fullName, string phoneNumber, string bloodType, string userId);
    }
}
