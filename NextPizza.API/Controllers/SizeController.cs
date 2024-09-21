using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using NextPizza.API.Contracts;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;

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
        public async Task<ActionResult<IReadOnlyCollection<SizeResponse>>> GetSizes()
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
            var sizeId = await _sizeService.UpdateAsync(id, size);

            if (sizeId.IsFailure)
            {
                return BadRequest(sizeId.Error);
            }

            return Ok(sizeId.Value);
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
        public async Task<ActionResult<SizeResponse>> GetSizeById(Guid id)
        {
            var result = await _sizeService.GetByIdAsync(id);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            var size = result.Value;

            return Ok(size);
        }
    }
}
