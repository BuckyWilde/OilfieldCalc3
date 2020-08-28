using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tubulars;

namespace OilfieldCalc3.Services
{
    public interface IDataService
    {
        Task<IEnumerable<T>> GetItemsSortedAsync<T>() where T : ITubular, new();
        Task<T> GetItemAsync<T>(int id) where T : ITubular, new();
        Task<int> SaveItemAsync(ITubular item);
        Task<int> DeleteItemAsync(ITubular item);
        Task<int> ClearTable<T>() where T : ITubular;
    }
}
