﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmp175.Models;
using cpm175.DataAccess;

public class EFSourseRepository : ISourseRepository
{
    private readonly ApplicationDbContext _context;

    public EFSourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sourse>> GetAllAsync()
    {
        return await _context.Sourses.ToListAsync();
    }

    public async Task<Sourse> GetByIdAsync(int id)
    {
        return await _context.Sourses.FindAsync(id);
    }

    public async Task AddAsync(Sourse product)
    {
        await _context.Sourses.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sourse product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var productToDelete = await _context.Sourses.FindAsync(id);
        if (productToDelete != null)
        {
            _context.Sourses.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }
}