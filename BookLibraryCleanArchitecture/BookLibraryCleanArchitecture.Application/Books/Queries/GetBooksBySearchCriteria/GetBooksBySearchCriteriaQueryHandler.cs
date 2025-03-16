using AutoMapper;
using BookLibraryCleanArchitecture.Application.Entities.Common;
using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Application.Extensions;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using BookLibraryCleanArchitecture.Shared;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookLibraryCleanArchitecture.Application.Books.Queries.GetBooksBySearchCriteria
{
    public class GetBooksBySearchCriteriaQueryHandler :
        IRequestHandler<GetBooksBySearchCriteriaQuery, Result<PagedResponse<BookDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksBySearchCriteriaQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper;
        }

        public async Task<Result<PagedResponse<BookDto>>> Handle(GetBooksBySearchCriteriaQuery query, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksAsync();
            var filteredBooks = _mapper.Map<IEnumerable<BookDto>>(books).AsQueryable();

            return await filteredBooks.CreatePagedReponseAsync(query.PageIndex, query.PageSize, query.SortColumn, query.SortDirection, query.Filters);
        }
    }
}
