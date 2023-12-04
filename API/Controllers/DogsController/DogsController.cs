using Application.Commands.Dogs;
using Application.Commands.Dogs.AddDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos.AnimalDtos.DogDto;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using Application.Validators.Dog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly DogValidator _dogValidator;
        public DogsController(IMediator mediator, DogValidator dogValidator)
        {
            _mediator = mediator;
            _dogValidator = dogValidator;
        }

        // Get all dogs from database (API Endpoint)
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new GetAllDogsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            //return Ok("GET ALL DOGS");
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }

        // Create a new dog 
        [HttpPost]
        [Authorize]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            //Validate Dog
            var validatedDog = _dogValidator.Validate(newDog);
            //Error handling
            if (!validatedDog.IsValid)
            {
                return BadRequest(validatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try catch
            try
            {
                return Ok(await _mediator.Send(new AddDogCommand(newDog)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }

        // Update a specific dog
        [HttpPut]
        [Authorize]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            //Validate Dog
            var validatedDog = _dogValidator.Validate(updatedDog);
            //Error handling
            if (!validatedDog.IsValid)
            {
                return BadRequest(validatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try catch
            try
            {
                return Ok(await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        // IMPLEMENT DELETE !!!

        [HttpDelete]
        [Authorize]
        [Route("deleteDog/{deletedDogId}")]
        public async Task<IActionResult> DeleteDog(Guid deletedDogId)
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new DeleteDogByIdCommand(deletedDogId)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



    }
}
