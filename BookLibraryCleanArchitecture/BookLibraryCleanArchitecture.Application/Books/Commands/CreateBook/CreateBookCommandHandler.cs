using AutoMapper;
using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Application.Extensions;
using BookLibraryCleanArchitecture.Domain.BookAggregate;
using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using BookLibraryCleanArchitecture.Shared.Errors;
using BookLibraryCleanArchitecture.Shared.Errors.General;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace BookLibraryCleanArchitecture.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<BookDto, Error>>
    {
        private IMapper _mapper;
        private ILogger<CreateBookCommandHandler> _logger;
        private IWriterRepository _writerRepository;
        private IReaderRepository _readerRepository;

        public CreateBookCommandHandler(
            IMapper mapper,
            ILogger<CreateBookCommandHandler> logger,
            IWriterRepository writerRepository,
            IReaderRepository readerRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _writerRepository = writerRepository;
            _readerRepository = readerRepository;
        }

        public async Task<Result<BookDto, Error>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Result<bool, ValidationError> validationResult = await command.ValidateAsync(new CreateBookCommandValidator(), cancellationToken);
                if (validationResult.IsFailure)
                    return validationResult.Error;

                var dbBook = _mapper.Map<Book>(command.Book);
                dbBook.Id = 0;

                // Handle Authors explicitly
                if (command.Authors?.Any() == true)
                {
                    var authors = await _readerRepository
                                        .Query<Author>()
                                        .Where(a => command.Authors.Contains(a.Id))
                                        .ToListAsync(cancellationToken);

                    if (authors.Count != command.Authors.Count())
                        return new ValidationError("authors.not.found", "Some authors were not found.");

                    foreach (var author in authors)
                        dbBook.Authors.Append(author); // assuming navigation property
                }

                await _writerRepository.AddAsync(dbBook, cancellationToken); //command.Authors);
                await _writerRepository.SaveChangesAsync(cancellationToken);
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
