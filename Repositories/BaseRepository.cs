﻿using SQLite;
using SQLiteNetExtensions.Extensions;
using VictuzMobile.Abstractions;
using VictuzMobile.Models;

namespace VictuzMobile

{
    public class BaseRepository<T> : IBaseRepository<T> where T : new()
    {
        private readonly SQLiteAsyncConnection connection;

        public BaseRepository(DatabaseContext context)
        {
            connection = context.Connection;
            context.CreateTableAsync<T>().Wait();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
                    }  

        public async Task<IEnumerable<T>?> GetAllAsync()
                {
            return await connection.Table<T>().ToListAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return default;
            }

                try
                {
                return await connection.GetAsync<T>(id);
            }
            catch (Exception ex)
            {
                return default;
            }

            return null;
        }

        public async Task AddAsync(T entity)
            {
                List<T> entity = new List<T>();

                try
                {
                await connection.InsertAsync(entity);
            } catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }

            return null;
        }
        public async Task UpdateAsync(T entity)
        {
            try
            {
                await connection.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}