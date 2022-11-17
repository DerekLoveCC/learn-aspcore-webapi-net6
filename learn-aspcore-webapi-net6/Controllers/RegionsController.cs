using AutoMapper;
using learn_aspcore_webapi_net6.Dtos;
using learn_aspcore_webapi_net6.Models.Domains;
using learn_aspcore_webapi_net6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace learn_aspcore_webapi_net6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();
            var resionDtos = _mapper.Map<List<RegionDto>>(regions);
            return Ok(resionDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName(nameof(GetRegionAsync))]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            var regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegionAsync(CreateRegionDto createRegionRequest)
        {
            var region = _mapper.Map<Region>(createRegionRequest);
            Region savedRegion = await _regionRepository.AddAsync(region);
            var dto = _mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetRegionAsync), new { id = dto.Id }, dto);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<RegionDto>(region);

            return Ok(dto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            var region = _mapper.Map<Region>(updateRegionDto);
            var updatedRegion = await _regionRepository.UpdateAsync(id, region);
            if (updatedRegion == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<RegionDto>(updatedRegion);

            return Ok(dto);
        }
    }
}