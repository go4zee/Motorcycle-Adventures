using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MotorcycleAdventures.Services
{
    public interface IRepository<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>>  Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate, bool forceRefresh = false);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool forceRefresh = false);
        T FirstOrDefault(Expression<Func<T, bool>> predicate, bool forceRefresh = false);
    }
}
