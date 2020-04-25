using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonor.Services.Data.BloodLabsServices
{
    public interface IBloodLabsService
    {
        IEnumerable<T> GetAll<T>();
        IEnumerable<T> GetLabsByTownName<T>(string town);

       T GetBloodLabById<T>(string id);
    }
}
