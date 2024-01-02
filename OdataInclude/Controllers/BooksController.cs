using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OdataInclude.Data;

namespace OdataInclude.Controllers
{

    public class BooksController : ODataController
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BooksController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_applicationDbContext.Books);
        }

        [HttpGet("odata/V1/Books({key})")]
        [EnableQuery]
        public IActionResult Get(Guid key)
        {
            var book = _applicationDbContext.Books.FirstOrDefault(b => b.Id == key);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("odata/V2/Books({key})")]
        [EnableQuery]
        public SingleResult GetV2(Guid key)
        {
            var book = _applicationDbContext.Books.Where(b => b.Id == key);
            return SingleResult.Create(book);
        }
    }
}
