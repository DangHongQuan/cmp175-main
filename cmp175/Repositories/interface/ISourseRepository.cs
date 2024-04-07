



using cmp175.Models;

public interface ISourceRepository
{
    Task<IEnumerable<Source>> GetAllAsync();
    Task<Source> GetByIdAsync(int id);
    Task AddAsync(Source product);
    Task UpdateAsync(Source product);
    Task DeleteAsync(int id);
}