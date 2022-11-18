using learn_aspcore_webapi_net6.Models.Domains;

namespace learn_aspcore_webapi_net6.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<List<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty?> GetAsync(Guid id);

        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);

        Task<WalkDifficulty?> DeleteAsync(Guid id);

        Task<WalkDifficulty?> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);
    }
}
