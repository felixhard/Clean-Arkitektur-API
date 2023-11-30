using Application.Queries.Users.GetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var user = await _mediator.Send(new GetTokenQuery(username, password));

            if (user == null)
            {
                return NotFound("Wrong user");
            }

            var token = user.token;
            return Ok(token);
        }
    }
}