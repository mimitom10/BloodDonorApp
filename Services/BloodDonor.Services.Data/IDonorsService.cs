namespace BloodDonor.Services.Data
{
    using System.Threading.Tasks;

    public interface IDonorsService
    {
        Task RegisterAsync(string fullName, string phoneNumber, string bloodType);
    }
}
