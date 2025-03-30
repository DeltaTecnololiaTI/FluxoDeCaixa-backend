﻿// Repositories/BaseRepository.cs
using FluxoDeCaixa.Domain.Interfaces;
using FluxoDeCaixa.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FluxoDeCaixa.Infra.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task UpdateAsync(T entity) => _dbSet.Update(entity);
        public async Task DeleteAsync(T entity) => _dbSet.Remove(entity);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}

