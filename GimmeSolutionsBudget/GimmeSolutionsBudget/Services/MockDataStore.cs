using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GimmeSolutionsBudget.Models;

[assembly: Xamarin.Forms.Dependency(typeof(GimmeSolutionsBudget.Services.MockDataStore))]
namespace GimmeSolutionsBudget.Services
{
    public class MockDataStore : IDataStore<Account>
    {
        List<Account> items;

        public MockDataStore()
        {
            items = new List<Account>();
            var mockItems = new List<Account>
            {
                new Account { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is an item description." },
                new Account { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is an item description." },
                new Account { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
                new Account { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
                new Account { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
                new Account { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddAccountAsync(Account item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAccountAsync(Account item)
        {
            var _item = items.Where((Account arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAccountAsync(Account item)
        {
            var _item = items.Where((Account arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Account> GetAccountAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}