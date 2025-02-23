using AutoMapper;
using BookLibraryCleanArchitecture.Server.Contracts;
using BookLibraryCleanArchitecture.Server.Entities.Common;
using BookLibraryCleanArchitecture.Server.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Server.Entities.Models;
using BookLibraryCleanArchitecture.Server.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace BookLibraryCleanArchitecture.Server.Services
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<BooksService> _logger;
        //private readonly IAuthorsService _authorsService;
        //private readonly ISendEmail _emailService;
        private readonly IMapper _mapper;
        private const int NoOfDaysForBookOnReturn = 10;
        private const int MaxNumberOfBooksToReserve = 3;
        private const int MaxNumberOfBooksToBorrow = 3;
        private const string DeleteReservationEmailSubject = "Deleted Reservation";
        private const string DeleteReservationEmailBody = "For book {0}, reservation will be deleted and also from the waiting list";

        public BooksService(ApplicationDbContext dbContext, ILogger<BooksService> logger,
                //IAuthorsService authorsService, ISendEmail emailService,
                IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            //_authorsService = authorsService;
            //_emailService = emailService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            _logger.LogDebug("Inside BooksService: GetBooksAsync method");

            return await _dbContext.Books.Select(b =>
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
                }).ToListAsync();
        }

        public async Task<PagedResponse<BookDto>> GetBySearchFiltersAsync(string sortDirection, int pageIndex = 1, int pageSize = 10, string sortColumn = "", Dictionary<string, string> filters = null)
        {
            IQueryable<BookDto> filteredBooks = _dbContext.Books.Select(_mapper.Map<Book, BookDto>).AsQueryable();
            var totalCount = filteredBooks.Count();
            if (pageIndex >= 0 && pageSize > 0)
            {
                filteredBooks = filteredBooks.Skip(pageIndex * pageSize)
                                .Take(pageSize);
            }

            if (filters != null)
            {
                string filterExpression;
                foreach (var filter in filters)
                {
                    if (filter.Value != null)
                    {
                        string columnName = $"{filter.Key[0].ToString().ToUpper()}{filter.Key.Substring(1)}";
                        string filterValue = filter.Value;

                        bool isStringColumn = typeof(Book).GetProperty(columnName)?.PropertyType == typeof(string);
                        if (!isStringColumn)
                        {
                            filterExpression = $"{columnName} == @0";
                        }
                        else
                        {
                            filterExpression = $"{columnName}.Contains(@0)";
                        }

                        // Apply the filter using Dynamic LINQ
                        filteredBooks = filteredBooks.Where(filterExpression, filterValue);
                    }
                }
            }

            IOrderedQueryable<BookDto> orderedBooks = filteredBooks as IOrderedQueryable<BookDto>;
            if (!string.IsNullOrEmpty(sortColumn))
            {
                // Build the dynamic sorting expression
                var orderByExpression = $"{sortColumn} {sortDirection}";

                // Apply dynamic sorting
                orderedBooks = filteredBooks.OrderBy(orderByExpression);

            }

            return new PagedResponse<BookDto> { Rows = orderedBooks, TotalItems = totalCount };
        }

    }
}
