using BookLibraryCleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BookLibraryCleanArchitecture.Domain.Contracts.Persistence
{
    public interface IReaderRepository
    {
        IQueryable<T> Query<T>() where T : BaseEntity;

        Task<T> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken)
            where T : BaseEntity;

        Task<IQueryable<T>> FindAsync<T>(CancellationToken cancellationToken,
                                         Expression<Func<T, bool>> filter = null,
                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            where T : BaseEntity;

        Task<IQueryable<T>> FindReadOnlyAsync<T>(CancellationToken cancellationToken,
                                                 Expression<Func<T, bool>> filter = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                 bool includeDeleted = false)
            where T : BaseEntity;
    }
}
