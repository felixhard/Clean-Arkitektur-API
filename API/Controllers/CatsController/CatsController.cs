using Application.Commands.Animals.Cats.AddCat;
using Application.Commands.Animals.Cats.UpdateCat;
using Application.Commands.Animals.Cats.DeleteCat;
using Application.Queries.Cats.GetByBreedAndWeight;
using Application.Dtos.AnimalDtos.CatDto;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using Application.Validators.Cat;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Animals.Cats;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly CatValidator _catValidator;
        public CatsController(IMediator mediator, CatValidator catValidator)
        {
            _mediator = mediator;
            _catValidator = catValidator;
        }

        // Get all Cats from database (API Endpoint)
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new GetAllCatsQuery()));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //return Ok("GET ALL CatS");
        }

        // Get a Cat by Id
        [HttpGet]
        [Route("getCatById/{CatId}")]
        public async Task<IActionResult> GetCatById(Guid CatId)
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new GetCatByIdQuery(CatId)));
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }

        // Create a new Cat 
        [HttpPost]
        [Authorize]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            //Validate Cat
            var validatedCat = _catValidator.Validate(newCat);
            //Error handling
            if (!validatedCat.IsValid)
            {
                return BadRequest(validatedCat.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try catch
            try
            {
                return Ok(await _mediator.Send(new AddCatCommand(newCat)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        // Update a specific Cat
        [HttpPut]
        [Authorize]
        [Route("updateCat/{updatedCatId}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            //Validate Cat
            var validatedCat = _catValidator.Validate(updatedCat);
            //Error handling
            if (!validatedCat.IsValid)
            {
                return BadRequest(validatedCat.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            //Try catch
            try
            {
                return Ok(await _mediator.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        [HttpGet]
        [Route("getCatsByBreedAndWeight")]
        public async Task<ActionResult<List<Cat>>> GetCatsByBreedAndWeight(
    [FromQuery] string breed,
    [FromQuery] int? weight)
        {
            try
            {
                var query = new GetCatsByBreedAndWeightQuery { Breed = breed, Weight = weight };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while getting cats of {breed} breed and weight from the database. Error details: {ex.Message}");
            }
        }

        // IMPLEMENT DELETE !!!

        [HttpDelete]
        [Authorize]
        [Route("deleteCat/{deletedCatId}")]
        public async Task<IActionResult> DeleteCat(Guid deletedCatId)
        {
            //Try catch
            try
            {
                return Ok(await _mediator.Send(new DeleteCatByIdCommand(deletedCatId)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
