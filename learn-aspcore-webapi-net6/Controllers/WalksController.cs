using AutoMapper;
using learn_aspcore_webapi_net6.Dtos;
using learn_aspcore_webapi_net6.Models.Domains;
using learn_aspcore_webapi_net6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace learn_aspcore_webapi_net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalksRepository _walksRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {
            _walksRepository = walksRepository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await _walksRepository.GetAllAsync();
            var resionDtos = _mapper.Map<List<WalkDto>>(walks);
            return Ok(resionDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walk = await _walksRepository.GetAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            var WalkDto = _mapper.Map<WalkDto>(walk);
            return Ok(WalkDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalkAsync(CreateWalkDto addWalkRequest)
        {
            var walk = _mapper.Map<Walk>(addWalkRequest);
            Walk savedWalk = await _walksRepository.AddAsync(walk);
            return Ok(savedWalk);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walk = await _walksRepository.DeleteAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<WalkDto>(walk);

            return Ok(dto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkDto updateWalkDto)
        {
            var walk = _mapper.Map<Walk>(updateWalkDto);
            var updatedWalk = await _walksRepository.UpdateAsync(id, walk);
            if (updatedWalk == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<WalkDto>(updatedWalk);

            return Ok(dto);
        }
    }
}