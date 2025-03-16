using AutoMapper;
using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Domain.BookAggregate;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;


namespace BookLibraryCleanArchitecture.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
    {
        private IMapper _mapper;
        private ILogger<CreateBookCommandHandler> _logger;
        private IBookRepository _bookRepository;

        public CreateBookCommandHandler(
            IMapper mapper,
            ILogger<CreateBookCommandHandler> logger,
            IBookRepository bookRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var dbBook = _mapper.Map<Book>(command.Book);
                dbBook.Id = 0;
                await _bookRepository.CreateBookAsync(dbBook, command.Authors);
                return _mapper.Map<BookDto>(dbBook);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CreateBookCommandHandler: Exception when trying to create the book {command.Book.Title}.");
                throw;
            }
        }
    }
}
