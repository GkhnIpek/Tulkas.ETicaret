using Microsoft.AspNetCore.Mvc;
using Tulkas.ETicaret.WebAPI.Errors;

namespace Tulkas.ETicaret.WebAPI.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Index(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
