using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ProjectListHiumanLab.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    [AcceptVerbs("GET", "POST", "PUT", "DELETE", "HEAD", "OPTIONS", "PATCH")]
    public IActionResult Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        return Problem(detail: context.Error.StackTrace, title: context.Error.Message);
    }
}