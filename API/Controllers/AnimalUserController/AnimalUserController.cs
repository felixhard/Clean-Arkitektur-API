using Application.Commands.AnimalUsers.Add;
using Application.Commands.AnimalUsers.Update;
using Application.Commands.AnimalUsers.Delete;
using Application.Queries.AnimalUsers.GetAll;
using Application.Queries.AnimalUsers.GetById;
using Application.Dtos.AnimalUserDto;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AnimalUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalUserController : ControllerBase
    {
        internal readonly IMediator _mediatR;
        internal readonly GuidValidator _guidValidator;

        public AnimalUserController(IMediator mediator, GuidValidator guidValidator)
        {
            _mediatR = mediator;
            _guidValidator = guidValidator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AnimalUserDto animalUserToCreate)
        {
            try
            {
                return Ok(await _mediatR.Send(new AddAnimalUserCommand(animalUserToCreate)));
            }
            catch (ArgumentException e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAllAnimalUsers")]
        public async Task<IActionResult> GetAllAnimalUsers()
        {
            try
            {
                var animalUsers = await _mediatR.Send(new GetAllAnimalUsersQuery());
                return Ok(animalUsers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("getAnimalUserById/{animalUserId}")]
        public async Task<IActionResult> GetAnimalUserById(Guid animalUserId)
        {
            var guidToValidate = _guidValidator.Validate(animalUserId);


            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new GetAnimalUserByIdQuery(animalUserId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("updateAnimalUser/{updatedAnimalUserId}")]
        public async Task<IActionResult> UpdateUser([FromBody] AnimalUserDto updatedAnimalUser, Guid updatedAnimalUserID)
        {


            try
            {
                return Ok(await _mediatR.Send(new UpdateAnimalUserByIdCommand(updatedAnimalUser, updatedAnimalUserID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("deleteAnimalUser/{deletedAnimalUserId}")]
        public async Task<IActionResult> DeleteAnimalUser(Guid deletedAnimalUserID)
        {
            var guidToValidate = _guidValidator.Validate(deletedAnimalUserID);

            // Error handling
            if (!guidToValidate.IsValid)
            {
                return BadRequest(guidToValidate.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new DeleteAnimalUserByIdCommand(deletedAnimalUserID)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
