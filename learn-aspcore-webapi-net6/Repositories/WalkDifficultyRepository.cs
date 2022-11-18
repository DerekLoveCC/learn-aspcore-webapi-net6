using learn_aspcore_webapi_net6.Data;
using learn_aspcore_webapi_net6.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace learn_aspcore_webapi_net6.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public WalkDifficultyRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            var savedWalkDifficulty = await _dbContext.AddAsync(walkDifficulty);
            await _dbContext.SaveChangesAsync();

            return savedWalkDifficulty.Entity;
        }

        public async Task<WalkDifficulty?> DeleteAsync(Guid id)
        {
            var walkDifficulty = await _dbContext.WalkDifficulty.FirstOrDefaultAsync(r => r.Id == id);
            if (walkDifficulty == null)
            {
                return null;
            }

            _dbContext.WalkDifficulty.Remove(walkDifficulty);
            await _dbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public Task<List<WalkDifficulty>> GetAllAsync()
        {
            return _dbContext.WalkDifficulty.ToListAsync();
        }

        public Task<WalkDifficulty?> GetAsync(Guid id)
        {
            return _dbContext.WalkDifficulty.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await _dbContext.WalkDifficulty.FirstOrDefaultAsync(r => r.Id == id);
            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;


            await _dbContext.SaveChangesAsync();

            return existingWalkDifficulty;
        }
    }
}