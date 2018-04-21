using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimmeSolutionsBudget.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAccountAsync(T account);
        Task<bool> UpdateAccountAsync(T account);
        Task<bool> DeleteAccountAsync(T account);
        Task<T> GetAccountAsync(string id);
        Task<IEnumerable<T>> GetAccountsAsync(bool forceRefresh = false);
    }
}
