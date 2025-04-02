using BookLibraryCleanArchitecture.Domain.Common;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BookLibraryCleanArchitecture.Infrastructure.Persistence.Repository
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly ApplicationDbContext _context;

        public ReaderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T:BaseEntity
        => _context.Set<T>().AsNoTracking();

        public async Task<T> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken) where T : BaseEntity
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IQueryable<T>> FindAsync<T>(CancellationToken cancellationToken,
                                                        Expression<Func<T, bool>> filter = null,
                                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : BaseEntity
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await Task.FromResult(query);
        }

        public async Task<IQueryable<T>> FindReadOnlyAsync<T>(CancellationToken cancellationToken,
                                                                Expression<Func<T, bool>> filter = null,
                                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                                bool includeDeleted = false) where T : BaseEntity
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await Task.FromResult(query);
        }
    }
}
