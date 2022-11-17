using learn_aspcore_webapi_net6.Data;
using learn_aspcore_webapi_net6.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace learn_aspcore_webapi_net6.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            var savedRegion = await _dbContext.AddAsync(region);
            await _dbContext.SaveChangesAsync();

            return savedRegion.Entity;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (region == null)
            {
                return null;
            }

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public Task<List<Region>> GetAllAsync()
        {
            return _dbContext.Regions.ToListAsync();
        }

        public Task<Region?> GetAsync(Guid id)
        {
            return _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await _dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
