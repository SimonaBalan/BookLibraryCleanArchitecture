using BookLibraryCleanArchitecture.Server.Entities.Common;
using BookLibraryCleanArchitecture.Server.Entities.DataTransferObjects;

namespace BookLibraryCleanArchitecture.Server.Contracts
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();//get all books

        Task<PagedResponse<BookDto>> GetBySearchFiltersAsync(string sortDirection, int pageIndex, int pageSize, string sortColumn, Dictionary<string, string> filters);
    }
}
