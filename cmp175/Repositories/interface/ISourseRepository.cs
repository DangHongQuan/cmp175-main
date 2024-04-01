



using cmp175.Models;

public interface ISourseRepository
{
    Task<IEnumerable<Sourse>> GetAllAsync();
    Task<Sourse> GetByIdAsync(int id);
    Task AddAsync(Sourse product);
    Task UpdateAsync(Sourse product);
    Task DeleteAsync(int id);
}