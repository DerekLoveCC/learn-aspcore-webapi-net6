using learn_aspcore_webapi_net6.Models.Domains;

namespace learn_aspcore_webapi_net6.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetAsync(Guid id);

        Task<Region> AddAsync(Region region);

        Task<Region?> DeleteAsync(Guid id);
    }
}
