using learn_aspcore_webapi_net6.Data;
using learn_aspcore_webapi_net6.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace learn_aspcore_webapi_net6.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public WalksRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            var savedRegion = await _dbContext.AddAsync(walk);
            await _dbContext.SaveChangesAsync();

            return savedRegion.Entity;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walk = await GetAsync(id);
            if (walk == null)
            {
                return null;
            }

            _dbContext.Walks.Remove(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public Task<List<Walk>> GetAllAsync()
        {
            return _dbContext.Walks
                .Include(w=>w.WalkDifficulty)
                .Include(w=>w.Region).ToListAsync();
        }

        public Task<Walk?> GetAsync(Guid id)
        {
            return _dbContext.Walks.Include(w => w.WalkDifficulty)
                .Include(w => w.Region).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await GetAsync(id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Length = walk.Length;
            existingWalk.Name = walk.Name;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
