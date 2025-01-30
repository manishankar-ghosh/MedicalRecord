using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }
        public void Update(T item)
        {
            _dbSet.Update(item);
        }
        public async Task DeleteAsync(int id)
        {
            T? item = await _dbSet.FindAsync(id);
            if (item != null)
            {
                _context.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("Item not found!");
            }
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
