using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserServiceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error/{code}")]
        [HttpGet]
       
        public IActionResult Error(int code) {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            return new ObjectResult(new ApiResponse(code,feature.Error.Message));
                }
    }
}
