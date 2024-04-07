using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmp175.Models;
using cpm175.DataAccess;

public class EFSourceRepository : ISourceRepository
{
    private readonly ApplicationDbContext _context;

    public EFSourceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Source>> GetAllAsync()
    {
        return await _context.Sources.ToListAsync();
    }

    public async Task<Source> GetByIdAsync(int id)
    {
        return await _context.Sources.FindAsync(id);
    }

    public async Task AddAsync(Source product)
    {
        await _context.Sources.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Source product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var productToDelete = await _context.Sources.FindAsync(id);
        if (productToDelete != null)
        {
            _context.Sources.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }
}