using Microsoft.AspNetCore.Mvc;
using NextPizza.API.Contracts;
using NextPizza.Application.Services;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;

namespace NextPizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoughTypeController : ControllerBase
    {
        private readonly IDoughTypesService _doughTypesService;

        public DoughTypeController(IDoughTypesService doughTypesService)
        {
            _doughTypesService = doughTypesService;
        }
        [HttpPost]
        public async Task<ActionResult> Create(DoughTypeRequest doughTypeRequest)
        {
            var doughType = DoughType.CreateNew(doughTypeRequest.Title, doughTypeRequest.ThicknessInCm).Value;
            var doughTypeResult = await _doughTypesService.CreateAsync(doughType);

            if (doughTypeResult.IsFailure)
            {
                return BadRequest(doughTypeResult.Error);
            }



            return Ok(doughTypeResult.Value);

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<DoughType>>> GetDoughTypes()
        {
            var doughTypeResult = await _doughTypesService.GetAllAsync();
            if (doughTypeResult.IsFailure)
            {
                return BadRequest(doughTypeResult.Error);
            }

            var sizes = doughTypeResult.Value;
            var response = sizes.Select(s => new SizeResponse(s.Id, s.Title, s.ThicknessInCm)).ToList();

            return Ok(response);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] DoughTypeRequest request)
        {
            var size = DoughType.CreateExisting(id, request.Title, request.ThicknessInCm).Value;
            var doughTypeResult = await _doughTypesService.UpdateAsync(id, size);
            if (doughTypeResult.IsFailure)
            {
                return BadRequest(doughTypeResult.Error);
            }

            return Ok(doughTypeResult.Value);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteResult = await _doughTypesService.DeleteAsync(id);
            if (deleteResult.IsFailure)
            {
                return BadRequest(deleteResult.Error);
            }
            return Ok(deleteResult.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DoughType>> GetById(Guid id)
        {
            var result = await _doughTypesService.GetByIdAsync(id);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            var sizes = result.Value;


            return Ok(sizes);
        }
    }
}
