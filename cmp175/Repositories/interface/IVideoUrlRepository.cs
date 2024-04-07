



using cmp175.Models;

public interface IVideoUrlRepository
{
    Task<IEnumerable<VideoURL>> GetAllAsync();
    Task<VideoURL> GetByIdAsync(int id);
    Task AddAsync(VideoURL product);
    Task UpdateAsync(Source product);
    Task DeleteAsync(VideoURL id);
}