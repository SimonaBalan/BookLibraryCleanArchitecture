using BookLibraryCleanArchitecture.Domain.Common;


namespace BookLibraryCleanArchitecture.Domain.Contracts.Persistence
{
    public interface IWriterRepository
    {
        Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity;
        Task<T> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity;
        Task<T> DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
