using Application.Commands.Users.Register;
using Application.Dtos.UserDtos;
using Application.Queries.Users.GetToken;
using Application.Validators;
using Application.Validators.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        internal readonly GuidValidator _guidValidator;
        internal readonly UserValidator _userValidator;

        public UsersController(IMediator mediator, GuidValidator guidValidator, UserValidator userValidator)
        {
            _mediatR = mediator;
            _guidValidator = guidValidator;
            _userValidator = userValidator;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> GetToken(string username, string password)
        {
            var user = await _mediatR.Send(new GetTokenQuery(username, password));

            if (user == null)
            {
                return NotFound("Wrong user");
            }

            var token = user.Token;
            return Ok(token);
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserCredentialsDto userToRegister)
        {
            var inputValidation = _userValidator.Validate(userToRegister);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new RegisterUserCommand(userToRegister)));
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                return BadRequest(e.Message);
            }
        }
    }
}