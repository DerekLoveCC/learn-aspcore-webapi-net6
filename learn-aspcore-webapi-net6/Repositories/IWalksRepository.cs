using learn_aspcore_webapi_net6.Models.Domains;

namespace learn_aspcore_webapi_net6.Repositories
{
    public interface IWalksRepository
    {
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetAsync(Guid id);

        Task<Walk> AddAsync(Walk walk);

        Task<Walk?> DeleteAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);
    }
}
