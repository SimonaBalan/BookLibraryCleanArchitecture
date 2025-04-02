using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Domain.BookAggregate;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using BookLibraryCleanArchitecture.Shared.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BookLibraryCleanArchitecture.Application.Books.Queries.GetBooksList
{
    public class GetBooksListQueryHandler :
        IRequestHandler<GetBooksListQuery, Result<IEnumerable<BookDto>, Error>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksListQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<Result<IEnumerable<BookDto>, Error>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Book> books = await _bookRepository.GetBooksAsync();
            return books.Select(b =>
                new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = b.Genre,
                    ISBN = b.ISBN,
                    NumberOfCopies = b.NumberOfCopies,
                    LoanedQuantity = b.LoanedQuantity,
                    NumberOfPages = b.NumberOfPages,
                    Publisher = b.Publisher,
                    ReleaseYear = b.ReleaseYear,
                    //Loans = b.Loans.ToList(),
                    //Reservations = b.Reservations.ToList(),  
                    //WaitingList = b.WaitingList.ToList(),
                    Authors = b.Authors.Select(a => a.Id).ToList()
                }).ToList();
        }
    }
}
