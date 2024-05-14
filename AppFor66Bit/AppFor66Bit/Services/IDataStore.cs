using AppFor66Bit.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFor66Bit.Services
{
    public interface IDataStore<T>
    {
        Task<bool> UpdateItemAsync(T item);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsFromDatabaseAsync(bool forceRefresh = false);
        IEnumerable<T> GetItems();
    }
}
