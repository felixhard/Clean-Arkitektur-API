using Application.Commands.Cats;
using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos.AnimalDtos.CatDto;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public CatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all Cats from database (API Endpoint)
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
            //return Ok("GET ALL CatS");
        }

        // Get a Cat by Id
        [HttpGet]
        [Route("getCatById/{CatId}")]
        public async Task<IActionResult> GetCatById(Guid CatId)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery(CatId)));
        }

        // Create a new Cat 
        [HttpPost]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediator.Send(new AddCatCommand(newCat)));
        }

        // Update a specific Cat
        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            return Ok(await _mediator.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId)));
        }

        // IMPLEMENT DELETE !!!

        [HttpDelete]
        [Route("deleteCat/{deletedCatID}")]
        public async Task<IActionResult> DeleteCat(Guid deletedCatID)
        {
            return Ok(await _mediator.Send(new DeleteCatByIdCommand(deletedCatID)));
        }



    }
}
