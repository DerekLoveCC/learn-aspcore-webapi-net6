using learn_aspcore_webapi_net6.Data;
using learn_aspcore_webapi_net6.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace learn_aspcore_webapi_net6.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Region>> GetAllAsync()
        {
            return _dbContext.Regions.ToListAsync();
        }

        public Task<Region?> GetAsync(Guid id)
        {
            return _dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
