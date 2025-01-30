using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IDbContextTransaction _currentTransaction;

        // Optional: Repository dictionary for generic repositories
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Repository accessor (optional for generic repositories)
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if(!_repositories.TryGetValue(typeof(TEntity), out var repository))
            {
                repository = new Repository<TEntity>(_context);
                _repositories[typeof(TEntity)] = repository;
            }
            //if (!_repositories.ContainsKey(typeof(TEntity)))
            //{
            //    var repository = new Repository<TEntity>(_context);
            //    _repositories[typeof(TEntity)] = repository;
            //}
            return (IRepository<TEntity>)repository;
        }

        // Save changes to the database
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        // Begin a new transaction
        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null) return; // Prevent nested transactions
            _currentTransaction = await _context.Database.BeginTransactionAsync();
        }

        // Commit the current transaction
        public async Task CommitTransactionAsync()
        {
            try
            {
                if (_currentTransaction == null) throw new InvalidOperationException("No transaction to commit.");
                await _context.SaveChangesAsync(); // Ensure changes are persisted
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        // Rollback the current transaction
        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_currentTransaction != null)
                    await _currentTransaction.RollbackAsync();
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        // Dispose of the transaction
        private async Task DisposeTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        // Dispose of the UnitOfWork
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }


}
