using Application.Commands.Birds;
using Application.Commands.Birds.AddBird;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos.AnimalDtos.BirdDto;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using Application.Validators.Bird;
using Application.Validators.Cat;
using Domain.Models.Cats;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BirdsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly BirdValidator _birdValidator;
        public BirdsController(IMediator mediator, BirdValidator birdValidator)
        {
            _mediator = mediator;
            _birdValidator = birdValidator;
        }

        // Get all Birds from database (API Endpoint)
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new GetAllBirdsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //return Ok("GET ALL Birds");
        }

        // Get a Bird by Id
        [HttpGet]
        [Route("getBirdById/{BirdId}")]
        public async Task<IActionResult> GetBirdById(Guid BirdId)
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new GetBirdByIdQuery(BirdId)));
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }

        // Create a new Bird
        [HttpPost]
        [Authorize]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            //Validate Bird
            var validatedBird = _birdValidator.Validate(newBird);
            //Error handling
            if (!validatedBird.IsValid)
            {
                return BadRequest(validatedBird.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try catch
            try
            {
                return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        // Update a specific Bird
        [HttpPut]
        [Authorize]
        [Route("updateBird/{updatedBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            //Validate Bird
            var validatedBird = _birdValidator.Validate(updatedBird);
            //Error handling
            if (!validatedBird.IsValid)
            {
                return BadRequest(validatedBird.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try catch
            try
            {
                return Ok(await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        // IMPLEMENT DELETE !!!

        [HttpDelete]
        [Authorize]
        [Route("deleteBird/{deletedBirdId}")]
        public async Task<IActionResult> DeleteBird(Guid deletedBirdId)
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new DeleteBirdByIdCommand(deletedBirdId)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
