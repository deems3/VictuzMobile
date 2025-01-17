using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictuzMobile.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : new()
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
