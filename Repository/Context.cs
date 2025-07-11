using SQLite;
using SmartCSLBlog.Models;

namespace SmartCSLBlog.Repository
{
    internal class Context
    {
        public SQLiteConnection database;

        public Context()
        {
            var sqliteHandle = new SQLiteHandle();
            database = sqliteHandle.DoesLocalDbExists ? new SQLiteConnection(sqliteHandle._databasePath) : GetSQLiteDBConnection();

            database.CreateTable<Posts>();
            database.CreateTable<Comments>();
        }

        private SQLiteConnection GetSQLiteDBConnection()
        {
            // Implement the logic to return a valid SQLiteConnection instance.  
            
            return new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, "blog.db3"));
        }
    }
}
