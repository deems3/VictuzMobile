using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictuzMobile.Abstractions;

namespace VictuzMobile.Models
{
    public class DatabaseContext
    {
        private SQLiteAsyncConnection _database;
        public SQLiteAsyncConnection Connection => _database;
        public DatabaseContext()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath);
        }

        public async Task CreateTableAsync<T>() where T : new()
        {
            await _database.CreateTableAsync<T>();
        }
    }
}
