using AutoMapper;
using learn_aspcore_webapi_net6.Dtos;
using learn_aspcore_webapi_net6.Models.Domains;
using learn_aspcore_webapi_net6.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();
            var resionDtos = _mapper.Map<List<RegionDto>>(regions);
            return Ok(resionDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName(nameof(GetRegionAsync))]
        [Authorize(Roles = "reader")]
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
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> CreateRegionAsync(CreateRegionDto createRegionRequest)
        {
            if (!ValidateCreateRegionAsync(createRegionRequest))
            {
                return BadRequest(ModelState);
            }

            var region = _mapper.Map<Region>(createRegionRequest);
            Region savedRegion = await _regionRepository.AddAsync(region);
            var dto = _mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetRegionAsync), new { id = dto.Id }, dto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
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
        [Authorize(Roles = "writer")]
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

        private bool ValidateCreateRegionAsync(CreateRegionDto createRegionRequest)
        {
            if (createRegionRequest == null)
            {
                ModelState.AddModelError(nameof(createRegionRequest), $"add region data is required");
                return false;
            }

            if (string.IsNullOrWhiteSpace(createRegionRequest.Code))
            {
                ModelState.AddModelError(nameof(createRegionRequest.Code), $"{nameof(createRegionRequest.Code)} cannot be null or empty or white space");
            }

            if (createRegionRequest.Long <= 0)
            {
                ModelState.AddModelError(nameof(createRegionRequest.Long), $"{nameof(createRegionRequest.Long)} cannot be less than zero");
            }

            if (createRegionRequest.Lat <= 0)
            {
                ModelState.AddModelError(nameof(createRegionRequest.Lat), $"{nameof(createRegionRequest.Lat)} cannot be less than zero");
            }

            if (createRegionRequest.Population <= 0)
            {
                ModelState.AddModelError(nameof(createRegionRequest.Population), $"{nameof(createRegionRequest.Population)} cannot be less than zero");
            }

            if (createRegionRequest.Area <= 0)
            {
                ModelState.AddModelError(nameof(createRegionRequest.Area), $"{nameof(createRegionRequest.Area)} cannot be less than zero");
            }

            return ModelState.ErrorCount == 0;
        }
    }
}