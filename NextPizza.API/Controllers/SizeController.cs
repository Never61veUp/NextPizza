using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using NextPizza.API.Contracts;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NextPizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizesService _sizeService;
        public SizeController(ISizesService sizeService)
        {

            _sizeService = sizeService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSize(SizeRequest sizeRequest)
        {
            var size = Size.CreateNew(sizeRequest.Title, sizeRequest.SizeInCm).Value;
            var sizeResult = await _sizeService.CreateAsync(size);

            if (sizeResult.IsFailure)
            {
                return BadRequest(sizeResult.Error);
            }



            return Ok(sizeResult.Value);

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Size>>> GetSizes()
        {
            var result = await _sizeService.GetAllAsync();
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            var sizes = result.Value;
            var response = sizes.Select(s => new SizeResponse(s.Id, s.Title, s.SizeInCm)).ToList();

            return Ok(response);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSize(Guid id, [FromBody] SizeRequest request)
        {
            var size = Size.CreateExisting(id, request.Title, request.SizeInCm).Value;
            var bookId = await _sizeService.UpdateAsync(id, size);
            if (bookId.IsFailure)
            {
                return BadRequest(bookId.Error);
            }

            return Ok(bookId.Value);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSize(Guid id)
        {
            var delSize = await _sizeService.DeleteAsync(id);
            if (delSize.IsFailure)
            {
                return BadRequest(delSize.Error);
            }
            return Ok(delSize.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Size>> GetSizeById(Guid id)
        {
            var result = await _sizeService.GetByIdAsync(id);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            var sizes = result.Value;


            return Ok(sizes);
        }
    }
}
