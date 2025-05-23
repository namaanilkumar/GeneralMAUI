using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralMAUI.Models;
using SQLite;

namespace GeneralMAUI.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public async Task InitAsync()
        {
            if (_database != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "appdata.db");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<CustomUser>();
        }

        public Task<List<CustomUser>> GetUsersAsync() => _database.Table<CustomUser>().ToListAsync();

        public Task<int> AddUserAsync(CustomUser user) => _database.InsertAsync(user);
    }
}
