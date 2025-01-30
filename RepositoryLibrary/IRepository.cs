using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        void Add(T item);
        void Update(T item);
        Task DeleteAsync(int id);
        Task<bool> Exists(Expression<Func<T, bool>> predicate);
    }
}
