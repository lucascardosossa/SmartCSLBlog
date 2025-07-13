using SQLite;
using SmartCSLBlog.Models;

namespace SmartCSLBlog.Repository
{
    public class Context
    {
        public SQLiteConnection database;

        public Context()
        {
            database = GetSQLiteDBConnection();

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
