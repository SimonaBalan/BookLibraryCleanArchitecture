using AutoMapper;
using BookLibraryCleanArchitecture.Application.Books.Commands.CreateBook;
using BookLibraryCleanArchitecture.Application.Books.Queries.GetBooksBySearchCriteria;
using BookLibraryCleanArchitecture.Application.Books.Queries.GetBooksList;
using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Domain.BookAggregate;
using BookLibraryCleanArchitecture.Server.Contracts;
using BookLibraryCleanArchitecture.Server.Filters;
using BookLibraryCleanArchitecture.Server.Models.ApiParameters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookLibraryCleanArchitecture.Server.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Administrator,NormalUser")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<BooksController> _loggerService;

        public BooksController(IMapper mapper, IMediator mediator, ILogger<BooksController> loggerService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _loggerService = loggerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            _loggerService.LogDebug("Start:BooksController-GetAllAsync");
            var query = new GetBooksListQuery();
            var books = await _mediator.Send(query);    

            _loggerService.LogDebug("End BooksController-GetAllAsync");
            return StatusCode(StatusCodes.Status200OK, books);
        }

        [HttpGet("getBySearchCriteriaAsync")]
        public async Task<IActionResult> GetBySearchCriteriaAsync([FromQuery] PaginatedListQueryParameters parameters)
        {
            var query = new GetBooksBySearchCriteriaQuery(parameters.PageIndex, parameters.PageSize, parameters.SortColumn, parameters.SortDirection, parameters.Filters);

            var books = await _mediator.Send(query);    

            return Ok(new { Books = books.Value.Rows.ToList(), TotalItems = books.Value.TotalItems });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ETag]
        public async Task<IActionResult> AddBookAsync(BookDto bookDto)
        {
            var addedDbBookCommand = new CreateBookCommand(bookDto, bookDto.Authors);

            var addedDbBook = await _mediator.Send(addedDbBookCommand);

            return CreatedAtAction("AddBook", new { id = addedDbBook.Value.Id }, bookDto);
        }
    }
}
