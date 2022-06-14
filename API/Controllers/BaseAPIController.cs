using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase {

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResults<T>(Result<T> result) {
            if (result == null)
                return NotFound();
            if (result.isSucess && result.value != null)
                return Ok(result.value);
            if (result.isSucess && result.value == null)
                return NotFound();

            return BadRequest(result.Error);
        }

    }
}
 