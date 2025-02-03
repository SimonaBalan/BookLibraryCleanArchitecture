using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryCleanArchitecture.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        //public IEnumerable<Book> Get()
        //{
        //    return null;
        //}
    }
}
