using System.Collections.Generic;

namespace MotorcycleAdventures.Persistence
{
    public interface ISQLiteDb<T, Context> where T : class where Context :ISQLiteDbContext
    {
        T Insert(T entity);

        bool InsertBulk(List<T> entities);

        bool Update(T entity);

        bool UpdateBulk(T entity);

        bool DeleteBulk(List<T> entities);

        bool Delete(T entity);

        bool Delete(int PrimaryID);
    }
}