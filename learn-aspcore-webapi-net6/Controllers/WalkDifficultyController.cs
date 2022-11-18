using AutoMapper;
using learn_aspcore_webapi_net6.Dtos;
using learn_aspcore_webapi_net6.Models.Domains;
using learn_aspcore_webapi_net6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace learn_aspcore_webapi_net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            _walkDifficultyRepository = walkDifficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _walkDifficultyRepository.GetAllAsync();
            var dtoList = _mapper.Map<List<WalkDifficultyDto>>(all);
            return Ok(dtoList);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var walkDifficulty = await _walkDifficultyRepository.GetAsync(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }

            return Ok(walkDifficulty);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateWalkDifficultyDto dto)
        {
            var walk = _mapper.Map<WalkDifficulty>(dto);

            var created = await _walkDifficultyRepository.AddAsync(walk);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = created.Id }, created);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateWalkDifficultyDto dto)
        {
            var walkDifficulty = _mapper.Map<WalkDifficulty>(dto);
            var updated = await _walkDifficultyRepository.UpdateAsync(id, walkDifficulty);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deleted = await _walkDifficultyRepository.DeleteAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }

            return Ok(deleted);
        }
    }
}