using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MotorcycleAdventures.Services
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection _connection;

        public Repository(SQLiteAsyncConnection connection)
        {
            _connection = connection;

            CreateTableResult createTableResult = _connection.CreateTableAsync<T>().Result;
        }

        public async Task<bool> AddItemAsync(T item)
        {
            return await _connection.InsertAsync(item) > 0;
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            return await _connection.UpdateAsync(item) > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await _connection.DeleteAsync<T>(id) > 0;
        }

        public async Task<T> GetItemAsync(string id)
        {
            return await _connection.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate, bool forceRefresh = false)
        {
            return await _connection.Table<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool forceRefresh = false)
        {
            return await _connection.Table<T>().FirstOrDefaultAsync(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate, bool forceRefresh = false)
        {
            return _connection.Table<T>().FirstOrDefaultAsync(predicate).Result;
        }

        public async Task<IEnumerable<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _connection.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = query.OrderBy<TValue>(orderBy);
            }

            var collection = new List<T>();
            var q = query.ToString();
            var items = await query.ToListAsync();
            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
