namespace BloodDonor.Services.Data.PatientsServices
{
    using System.Threading.Tasks;

    public interface IPatientsService
    {
        bool IsRegisteredPatient(string userId);

        Task RegisterAsync(string fullName, string phoneNumber, string bloodType, string locationId, string userId);

        T GetPatientByUserId<T>(string userId);
    }
}
