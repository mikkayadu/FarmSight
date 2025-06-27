using System;
using System.Threading.Tasks;

namespace FarmSightWebApi.ApplicationCore.ServiceContracts
{
    public interface IEODataFetchService
    {
        Task<bool> FetchAndSaveEODataForFieldAsync(Guid fieldId, DateTime date);
        Task<int> FetchForAllFieldsAsync(DateTime date); // for scheduled jobs
    }
}
