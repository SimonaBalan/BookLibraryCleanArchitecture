using BookLibraryCleanArchitecture.Application.Entities.Common;
using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using CSharpFunctionalExtensions;
using MediatR;

namespace BookLibraryCleanArchitecture.Application.Books.Queries.GetBooksBySearchCriteria
{
    public record GetBooksBySearchCriteriaQuery(int PageIndex, int PageSize, string SortColumn, string SortDirection,
        Dictionary<string,string> Filters) : IRequest<Result<PagedResponse<BookDto>>>;
    
}
