using System;
using System.IO;
using MotorcycleAdventures.Core;
using MotorcycleAdventures.iOS.Persistence;
using MotorcycleAdventures.Persistence;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDbContext))]
namespace MotorcycleAdventures.iOS.Persistence
{
    public class SQLiteDbContext : ISQLiteDbContext
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, Constants.DbName);

            return new SQLiteAsyncConnection(path);
        }
    }
}