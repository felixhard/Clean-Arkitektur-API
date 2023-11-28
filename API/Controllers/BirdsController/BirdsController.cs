using Application.Commands.Birds;
using Application.Commands.Birds.AddBird;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos.AnimalDtos.BirdDto;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.BirdsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public BirdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all Birds from database (API Endpoint)
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
            //return Ok("GET ALL Birds");
        }

        // Get a Bird by Id
        [HttpGet]
        [Route("getBirdById/{BirdId}")]
        public async Task<IActionResult> GetBirdById(Guid BirdId)
        {
            return Ok(await _mediator.Send(new GetBirdByIdQuery(BirdId)));
        }

        // Create a new Bird
        [HttpPost]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
        }

        // Update a specific Bird
        [HttpPut]
        [Route("updateBird/{updatedBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            return Ok(await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId)));
        }

        // IMPLEMENT DELETE !!!

        [HttpDelete]
        [Route("deleteBird/{deletedBirdId}")]
        public async Task<IActionResult> DeleteBird(Guid deletedBirdId)
        {
            return Ok(await _mediator.Send(new DeleteBirdByIdCommand(deletedBirdId)));
        }



    }
}
