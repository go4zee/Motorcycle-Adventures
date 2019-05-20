using SQLite;

namespace MotorcycleAdventures.Persistence
{
    public interface ISQLiteDbContext
    {
        SQLiteAsyncConnection GetConnection();
    }
}
