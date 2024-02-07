using Application.Commands.Users.Register;
using Application.Commands.Users.Update;
using Application.Commands.Users.Delete;
using Application.Dtos.UserDtos;
using Application.Queries.Users.GetAllUsers;
using Application.Queries.Users.GetToken;
using Application.Queries.Users.GetUserById;
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

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _mediatR.Send(new GetAllUsersQuery());
                return Ok(users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("getUserById/{userId}")]
        //[Authorize]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var guidToValidate = _guidValidator.Validate(userId);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new GetUserByIdQuery(userId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("deleteUser/{deletedUserId}")]
        //[Authorize]
        public async Task<IActionResult> DeleteUser(Guid deletedUserId)
        {
            var guidToValidate = _guidValidator.Validate(deletedUserId);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new DeleteUserCommand(deletedUserId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("uppdateUser/{updatedUserId}")]
        //[Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserCredentialsDto updatedUser, Guid updatedUserId)
        {
            // Validate user
            var userToValidate = _userValidator.Validate(updatedUser);

            if (!userToValidate.IsValid)
            {
                return BadRequest(userToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new UpdateUserCommand(updatedUser, updatedUserId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}