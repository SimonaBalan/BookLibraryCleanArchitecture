

using BookLibraryCleanArchitecture.Domain.Common;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryCleanArchitecture.Infrastructure.Persistence.Repository
{
    public class WriterRepository : IWriterRepository
    {
        private readonly ApplicationDbContext _context;

        public WriterRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<T> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public async Task<T> DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity
        {
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
            return entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
