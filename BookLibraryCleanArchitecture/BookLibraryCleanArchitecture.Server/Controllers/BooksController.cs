using BookLibraryCleanArchitecture.Server.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryCleanArchitecture.Server.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Administrator,NormalUser")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ILogger<BooksController> _loggerService;

        public BooksController(IBooksService booksService, ILogger<BooksController> loggerService)
        {
            _booksService = booksService;
            _loggerService = loggerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _loggerService.LogDebug("Start:BooksController-GetAllAsync");
            var books = await _booksService.GetBooksAsync();

            _loggerService.LogDebug("End BooksController-GetAllAsync");
            return StatusCode(StatusCodes.Status200OK, books);
        }

        [HttpGet("getBySearchCriteriaAsync")]
        public async Task<IActionResult> GetBySearchCriteriaAsync(string sortDirection, int pageIndex = 1, int pageSize = 10, string sortColumn = "", Dictionary<string, string> filters = null)
        {
            var pagedResponseBooks = await _booksService.GetBySearchFiltersAsync(sortDirection, pageIndex, pageSize, sortColumn, filters);

            return Ok(new { Books = pagedResponseBooks.Rows.ToList(), TotalItems = pagedResponseBooks.TotalItems });
        }
    }
}
