using Microsoft.AspNetCore.Mvc;
using Tulkas.ETicaret.Infrastructure.DataContext;
using Tulkas.ETicaret.WebAPI.Errors;

namespace Tulkas.ETicaret.WebAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _context;

        public BuggyController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var product = _context.Products.Find(10);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            var product = _context.Products.Find(10);
            var productDto = product.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
