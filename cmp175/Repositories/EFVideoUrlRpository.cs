using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using cmp175.Models;
using cpm175.DataAccess;

public class  EFVideoUrlRpository : IVideoUrlRepository
{
    private readonly ApplicationDbContext _context;

    public EFVideoUrlRpository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VideoURL>> GetAllAsync()
    {
        return await _context.VideoUrls.ToListAsync();
    }

    public async Task<VideoURL> GetByIdAsync(int id)
    {
        return await _context.VideoUrls.FindAsync(id);
    }

    public async Task AddAsync(VideoURL videoUrl)
    {
        await _context.VideoUrls.AddAsync(videoUrl);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(Sourse product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(VideoURL id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(VideoURL videoUrl)
    {
        _context.Entry(videoUrl).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var videoUrlDelete = await _context.VideoUrls.FindAsync(id);
        if (videoUrlDelete != null)
        {
            _context.VideoUrls.Remove(videoUrlDelete);
            await _context.SaveChangesAsync();
        }
    }
}